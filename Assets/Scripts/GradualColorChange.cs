using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradualColorChange : MonoBehaviour
{
    public float changeInterval = 15f; // interval in seconds between color changes
    private SpriteRenderer spriteRenderer; // reference to the SpriteRenderer component
    private Color originalColor; // the original color of the sprite
    private Color targetColor; // the target color to change to
    private float t = 0f; // current time

    void Start()
    {
        // get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // save the original color of the sprite
        originalColor = spriteRenderer.color;

        // start the color change coroutine
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            // pick a random color to change to
            targetColor = new Color(Random.value, Random.value, Random.value);

            // interpolate between the original color and the target color over time
            while (t < changeInterval)
            {
                t += Time.deltaTime;
                spriteRenderer.color = Color.Lerp(originalColor, targetColor, t / changeInterval);
                yield return null;
            }

            // reset the timer and go back to the original color
            t = 0f;
            originalColor = targetColor;
            spriteRenderer.color = originalColor;
            yield return null;
        }
    }
}
