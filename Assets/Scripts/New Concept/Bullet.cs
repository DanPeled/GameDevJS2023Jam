using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public void Seek(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void HitTarget()
    {
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation) as GameObject;
        Destroy(effect, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}