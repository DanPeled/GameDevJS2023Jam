using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;
    public static int health;
    public int startHealth = 20;
    public static int rounds;
    public static PlayerStats i;
    public void Init()
    {
        money = startMoney;
        health = startHealth;

        rounds = 0;
    }
    void Start()
    {
        Init();
    }
    void Awake()
    {
        i = this;
    }
}
