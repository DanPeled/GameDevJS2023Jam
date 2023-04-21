using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    
    public float startSpeed = 5f;
    public int reward = 1;
    public float health = 100;

    void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1 - pct);
    }
    void Die()
    {
        PlayerStats.money += reward;
        Destroy(gameObject);
    }
}