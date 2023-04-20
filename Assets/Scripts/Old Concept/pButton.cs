using UnityEngine;

public class pButton : MonoBehaviour
{
    public GameObject other;
    public bool initialState = true;
    public bool active;
    void Start()
    {
        active = initialState;
    }
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
    public void SetActive(bool state)
    {
        active = state;
    }
}