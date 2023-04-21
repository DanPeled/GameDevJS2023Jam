using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;

    [Header("Use bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float fireCountdown = 0;

    [Header("Use laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    [Header("Refrences")]
    public string enemyTag = "enemy";
    public float turnSpeed = 10;
    public Transform rotator;
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.01f);
    }
    void Update()
    {
        if (target == null)
        {
            if (useLaser && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                impactEffect.Stop();
            }

            return;
        }

        LockOnTarget();
        if (this.useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }
    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);
        if (!lineRenderer.enabled)
        {
            impactEffect.Play();
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);


        impactEffect.transform.position = target.position;
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(this.rotator.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        this.rotator.rotation = Quaternion.Euler(0f, 0f, rotation.z);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}