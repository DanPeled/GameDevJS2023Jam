using UnityEngine;

public class pButton : MonoBehaviour
{
    public GameObject other;

    public bool active = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ButtonActivator>() != null && active)
            this.other = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.other = null;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ButtonActivator>() != null && active)
            this.other = other.gameObject;
    }
    void Update()
    {
        if (!active)
        {
            this.other = null;
        }
    }
}