using UnityEngine;
using UnityEngine.Events;
public class BombTrigger : MonoBehaviour
{
    SpriteRenderer sr;
    public UnityEvent onTrigger;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        var bomb = other.GetComponent<Bomb>();
        if (bomb != null)
        {
            bomb.active = false;
            Instantiate(ParticaleEffects.i.explosion, bomb.transform.position, Quaternion.identity);
            bomb.transform.position = bomb.originalPos;
            bomb.gameObject.SetActive(false);
            onTrigger?.Invoke();
            gameObject.SetActive(false);
        }
    }
}