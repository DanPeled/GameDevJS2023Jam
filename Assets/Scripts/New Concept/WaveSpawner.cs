using System.Collections;
using UnityEngine;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public GameObject normalEnemy, toughEnemy, superToughEnemy;
    public Transform spawnPoint;
    public float originalTimeBetweenWaves = 5f;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TextMeshProUGUI waveCountText;
    public TextMeshProUGUI waveCountdownText;
    public int wave = 1;
    public int wavesRequired;
    public static WaveSpawner i;

    void Awake()
    {
        spawnPoint = GameObject.Find("START").transform;
        i = this;
    }
    void Update()
    {
        if (enemiesAlive > 0 || PlayerStats.health < 0)
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
            if (PlayerStats.health < 0)
                break;
            GameObject enemy = Random.Range(0, 3 * wave) >= 3 && wave > 10 ? toughEnemy :
            (wave > 15 && Random.Range(0, 5 * wave) >= 5 ? superToughEnemy : normalEnemy);
            if (wave > 100) enemy = superToughEnemy;
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(Random.Range(0.3f, 0.5f));
        }
        Debug.Log("wave incoming");
    }
    void SpawnEnemy(GameObject enemyPrefab)
    {
        enemiesAlive++;
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}