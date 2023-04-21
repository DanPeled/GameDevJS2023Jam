using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager i;
    private TurretBlueprint turretToBuild;
    private Tile selectedTile;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.price; } }
    public TileUI nodeUI;
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
        DeselectNode();
    }
    public void SelectNode(Tile tile)
    {
        if (selectedTile == tile)
        {
            DeselectNode();
            return;
        }
        selectedTile = tile;
        turretToBuild = null;

        nodeUI.SetTarget(tile);
    }
    public void DeselectNode()
    {
        selectedTile = null;
        nodeUI.Hide();
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
