using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Vector3 playerPos;
    private SpriteRenderer sr;
    public int index = 0;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null && playerPos == Vector3.zero)
        {
            other.GetComponent<CheckPointHandler>().checkPoint = this;
        }
    }

    public void Save()
    {
        playerPos = PlayerController.i.transform.position;
    }
    public void Load()
    {
        PlayerController.i.transform.position = playerPos;
        PlayerController.i.rb.velocity = Vector2.zero;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            Save();
        }
    }
}