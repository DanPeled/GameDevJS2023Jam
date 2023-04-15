using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    private Camera cam;
    public Transform playerTransform;
    void OnValidate()
    {
        transform.position = playerTransform.position + offset;
    }
    public void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}