using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }
    void Update()
    {
        var speedBoost = WaveSpawner.i.wave > 25 ? Mathf.Clamp(WaveSpawner.i.wave / 3, 0, 3) :
         Mathf.Clamp(WaveSpawner.i.wave / 4f, 0, 2.5f);
        Vector3 dir = target.position - transform.position;
        if (PlayerStats.health > 0)
            transform.Translate(dir.normalized * enemy.speed * Time.deltaTime *
            (speedBoost), Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStats.health--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}