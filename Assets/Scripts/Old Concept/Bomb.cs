using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float time = 60f, originalTime;
    public bool active = true, initialState = true;
    public Vector3 originalPos;

    private void Awake()
    {
        active = initialState;
        originalTime = time;
        originalPos = transform.position;
    }

    private void Update()
    {
        if (active)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0f)
        {
            active = false;
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        CheckPointHandler.i.Restart();
        AudioManager.i.PlaySFX("pop");
        GameObject exp = Instantiate(ParticaleEffects.i.explosion, transform.position, Quaternion.identity);
        yield return null;
        CheckPointHandler.i.Restart();
        this.gameObject.SetActive(false);
    }

    public void SetActive(bool state)
    {
        active = state;
    }

    private void OnEnable()
    {
        AudioManager.i.PlaySFX("ignite");
    }
}
