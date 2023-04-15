using System;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class ButtonConnector
{
    public string name;
    public pButton button;
    public  ButtonActivator buttonActivator;
    public UnityEvent onPressed;
    public UnityEvent onUp;
}