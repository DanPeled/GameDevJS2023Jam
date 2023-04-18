using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class BombHandler : MonoBehaviour
{
    public static BombHandler Instance { get; private set; }

    public Bomb bomb;
    public TextMeshProUGUI timeTxt, deathText;
    public Animator deathTextAnimator;
    public int deathCount;

    private List<Bomb> bombs = new List<Bomb>();

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!bomb.active)
        {
            timeTxt.text = "";
            return;
        }

        TimeSpan ts = TimeSpan.FromSeconds(bomb.time);
        timeTxt.text = string.Format("{0:D2}:{1:D2}:{2:D3}", ts.Minutes, ts.Seconds, ts.Milliseconds);

        bombs.Clear();
        Bomb[] bombArray = FindObjectsOfType<Bomb>();
        for (int i = 0; i < bombArray.Length; i++)
        {
            if (bombArray[i].active)
            {
                bombs.Add(bombArray[i]);
            }
        }

        if (bombs.Count == 1)
        {
            bomb = bombs[0];
        }

        if (bomb.time <= 0 && bomb.active)
        {
            StartCoroutine(OnDeath());
        }
    }

    private IEnumerator OnDeath()
    {
        var exp = Instantiate(ParticaleEffects.i.explosion, bomb.transform.position, Quaternion.identity);
        bomb.time = 0;
        bomb.active = false;
        deathCount++;
        AudioManager.i.PlaySFX("pop");
        deathText.text = deathCount.ToString();

        deathTextAnimator.SetBool("Show", true);
        yield return new WaitForSeconds(deathTextAnimator.GetCurrentAnimatorClipInfo(0).Length);
        deathTextAnimator.SetBool("Show", false);
        deathText.text = "";
        CheckPointHandler.i.Restart();
        Destroy(exp);
        yield return null;
        CheckPointHandler.i.Restart();
    }

    public void SetBomb(Bomb b)
    {
        bomb = b;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Bomb b = other.gameObject.GetComponent<Bomb>();
        if (b != null && b.active)
        {
            bomb = b;
        }
    }
}
