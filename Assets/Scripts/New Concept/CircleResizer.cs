using UnityEngine;

public class CircleResizer : MonoBehaviour
{
    public float radius = 1.0f; // The radius of the circle

    private void Update()
    {
        // Calculate the circumference and area based on the radius
        float circumference = 2 * Mathf.PI * radius;
        float area = Mathf.PI * radius * radius;

        // Calculate the scale factor based on the circumference
        Vector3 scaleFactor = new Vector3(circumference, circumference, 1) / Mathf.PI;

        // Set the scale of the circle transform
        transform.localScale = scaleFactor;
    }
}
