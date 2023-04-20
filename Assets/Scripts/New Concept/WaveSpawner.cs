using System.Collections;
using UnityEngine;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float originalTimeBetweenWaves = 5f;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TextMeshProUGUI waveCountText;
    public TextMeshProUGUI waveCountdownText;
    public int wave = 1;
    public static WaveSpawner i;
    public int enemyCount = 0;

    void Awake()
    {
        i = this;
    }
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {
        waveCountText.text = $"WAVE: {wave}";
        for (int i = 0; i < wave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f);
        }
        wave++;
        Debug.Log("wave incoming");
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}