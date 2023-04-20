using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret, missleLauncher;
    void Start()
    {
        buildManager = BuildManager.i;
    }
    public void SelectStandardTurret(){
        buildManager.SelectTurretToBuild(standardTurret);
    }
}
