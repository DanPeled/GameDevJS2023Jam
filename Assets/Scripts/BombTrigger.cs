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
        if (this.bomb == null)
        {
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
            var exp = Instantiate(ParticaleEffects.i.explosion, bomb.transform.position, Quaternion.identity); // spawn a explosion effect
            bomb.transform.position = bomb.originalPos; // reset bomb pos
            bomb.gameObject.SetActive(false); // disable bomb
            onTrigger?.Invoke(); // trigger onTrigger event
            bc.enabled = (false); // disable this script's 2D box collider
            AudioManager.i.PlaySFX("pop");
        }
    }
}