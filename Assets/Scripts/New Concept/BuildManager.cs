using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager i;
    private TurretBlueprint turretToBuild;
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.price; } }
    void Awake()
    {
        if (i != null)
        {
            Debug.LogError("There is more than one BuildManager in the scene");
            return;
        }
        i = this;

    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        this.turretToBuild = turret;
    }
    public void BuildTurretOn(Tile tile)
    {
        if (PlayerStats.money < turretToBuild.price)
        {
            return;
        }
        PlayerStats.money -= turretToBuild.price;
        // build a turret
        GameObject turret = Instantiate(turretToBuild.prefab, new Vector3(tile.GetBuildPos().x, tile.GetBuildPos().y, 0), tile.transform.rotation);
        tile.turret = turret;
    }
}
