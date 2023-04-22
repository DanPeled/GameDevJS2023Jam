using System.Collections;
using UnityEngine;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float originalTimeBetweenWaves = 5f;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TextMeshProUGUI waveCountText;
    public TextMeshProUGUI waveCountdownText;
    public int wave = 1;
    public static WaveSpawner i;

    void Awake()
    {
        i = this;
    }
    void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {
        wave++;
        PlayerStats.rounds++;
        waveCountText.text = $"WAVE: {wave}";
        for (int i = 0; i < wave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(0.3f, 0.5f));
        }
        Debug.Log("wave incoming");
    }
    void SpawnEnemy()
    {
        enemiesAlive++;
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}