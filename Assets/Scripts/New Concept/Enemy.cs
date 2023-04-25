using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public float startSpeed = 5f;
    public int reward = 1;
    public float startHealth = 100f;
    public float health;

    void Start()
    {
        health = startHealth;
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

        AudioManager.i.PlaySFX("hit");

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }
}