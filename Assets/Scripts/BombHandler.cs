using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using UnityEngine;
using TMPro;
public class BombHandler : MonoBehaviour
{
    public static BombHandler i;
    public Bomb bomb;
    public TextMeshProUGUI timeTxt, deathText;
    public Animator deathTextAnimator;
    public int deathCount;
    void Awake()
    {
        i = this;
    }
    void Update()
    {
        TimeSpan ts = TimeSpan.FromSeconds(bomb.time); // Convert deltaTime to TimeSpan
        string timeString = string.Format("{0:D2}:{1:D2}:{2:D3}", ts.Minutes, ts.Seconds, ts.Milliseconds); // Format the TimeSpan as "MM:SS:fff"
        if (!bomb.active)
        {
            timeTxt.text = ""; // clear the timetxt text if the bomb isnt active
        }
        else
            timeTxt.text = timeString; // Set the formatted time to the timeTxt text

        // remove each inactive bomb from the list, and if theres only one active, change the bomb var to it
        List<Bomb> bombs = FindObjectsOfType<Bomb>().ToList();
        bombs.RemoveAll(b => !b.active);
        if (bombs.Count == 1)
        {
            bomb = bombs[0];
        }
        if (bomb.time <= 0 && bomb.active)
        {
            StartCoroutine(OnDeath());
        }

    }
    IEnumerator OnDeath()
    {
        bomb.time = 0;
        bomb.active = false;

        deathCount++;

        deathText.text = $"{deathCount}";

        deathTextAnimator.SetBool("Show", true);
        yield return new WaitForSeconds(deathTextAnimator.GetCurrentAnimatorClipInfo(0).Length);
        deathTextAnimator.SetBool("Show", false);
        deathText.text = "";
        CheckPointHandler.i.Restart();
    }
    public void SetBomb(Bomb b)
    {
        this.bomb = b;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Bomb>() != null)
        {
            this.bomb = other.gameObject.GetComponent<Bomb>();
        }
    }
}