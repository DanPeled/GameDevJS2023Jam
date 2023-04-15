using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public GameObject other;
    public bool triggerRepeatedly = true;
    private Rigidbody2D rb;
    public Vector3 originalPos;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = transform.position;
    }
    void Update()
    {

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            rb.velocity = Vector2.zero;
        if (other.gameObject.GetComponent<pButton>() != null)
            this.other = null;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<pButton>() != null)
            this.other = other.gameObject;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<pButton>() != null)
            if (triggerRepeatedly)
            {
                this.other = other.gameObject;
            }
    }
}