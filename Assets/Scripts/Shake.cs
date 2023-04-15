using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool start;
    public float duration = 1f;
    public AnimationCurve curve;

    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPos = transform.position;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strengh = curve.Evaluate(elapsedTime / duration);
            transform.position += startPos + Random.insideUnitSphere * strengh;
            yield return null;
        }
        transform.position = startPos;
    }
}