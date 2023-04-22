using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret, missleLauncher, laserBeamer;
    public TextMeshProUGUI standardtext, missletext, laserbeamertext;
    void Start()
    {
        buildManager = BuildManager.i;
        standardtext.text = $"${standardTurret.price}";
        //missletext.text = $"${missleLauncher.price}";
        laserbeamertext.text = $"${laserBeamer.price}";
    }
    void Update()
    {
        int money = PlayerStats.money;

        if (money != PlayerStats.money)
        {
            standardtext.color = standardtext != null && standardTurret.price >= PlayerStats.money ? Color.white : Color.red;
            missletext.color = missletext != null && missleLauncher.price >= PlayerStats.money ? Color.white : Color.red;
            laserbeamertext.color = laserbeamertext != null && laserBeamer.price >= PlayerStats.money ? Color.white : Color.red;
        }
    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissleLauncher()
    {
        buildManager.SelectTurretToBuild(missleLauncher);
    }
    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
