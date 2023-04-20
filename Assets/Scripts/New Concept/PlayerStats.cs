using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;
    public static int health = 100;

    void Start()
    {
        money = startMoney;
    }
}
