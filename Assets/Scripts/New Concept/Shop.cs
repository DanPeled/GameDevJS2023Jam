using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret, missleLauncher, laserBeamer;
    void Start()
    {
        buildManager = BuildManager.i;
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
