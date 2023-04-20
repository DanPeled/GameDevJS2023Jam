using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    private Camera cam;
    public Transform playerTransform;
    public static CameraController i;
    void OnValidate()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + offset;
        }
    }
    public void Awake()
    {
        i = this;
        cam = GetComponent<Camera>();
    }

    public void Update()
    {
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x + offset.x,
             playerTransform.position.y + offset.y,
              -10);
        }
    }
}