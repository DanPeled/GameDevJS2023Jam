using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float time = 60;
    public bool active;
    public Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
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
}
