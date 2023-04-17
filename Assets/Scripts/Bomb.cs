using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float time = 60, originalTime;
    public bool active, initialState = true;
    public Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalTime = time;
        originalPos = transform.position;
        active = initialState;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            time -= Time.deltaTime;
        }
    }
    void OnDestroy()
    {
        active = false;
    }
    public void SetActive(bool state)
    {
        active = state;
    }
    void OnEnable()
    {
        AudioManager.i.PlaySFX("ignite");
    }
}
