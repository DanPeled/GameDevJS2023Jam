using System;
using UnityEngine;
using TMPro;
public class BombHandler : MonoBehaviour
{
    public static BombHandler i;
    public Bomb bomb;
    public TextMeshProUGUI timeTxt;
    void Awake()
    {
        i = this;
    }
    void Update()
    {
        TimeSpan ts = TimeSpan.FromSeconds(bomb.time); // Convert deltaTime to TimeSpan
        string timeString = string.Format("{0:D2}:{1:D2}:{2:D3}", ts.Minutes, ts.Seconds, ts.Milliseconds); // Format the TimeSpan as "MM:SS:fff"
        timeTxt.text = timeString; // Set the formatted time to the timeTxt text

    }
    public void SetBomb(Bomb b)
    {
        this.bomb = b;
    }
}