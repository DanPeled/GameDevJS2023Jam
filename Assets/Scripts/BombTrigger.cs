using UnityEngine;
using UnityEngine.Events;
public class BombTrigger : MonoBehaviour
{
    Bomb bomb;
    SpriteRenderer sr;
    public UnityEvent onTrigger, onNotTriggered;
    [HideInInspector]
    public BoxCollider2D bc;
    void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
    void Update()
    {
        if (this.bomb == null){
            onNotTriggered?.Invoke();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        var bomb = other.GetComponent<Bomb>();
        this.bomb = bomb;
        if (bomb != null)
        {
            bomb.active = false;
            Instantiate(ParticaleEffects.i.explosion, bomb.transform.position, Quaternion.identity);
            bomb.transform.position = bomb.originalPos;
            bomb.gameObject.SetActive(false);
            onTrigger?.Invoke();
            bc.enabled = (false);
        }
    }
}