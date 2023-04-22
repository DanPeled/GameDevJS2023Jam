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
    private TurretBlueprint tempTurret;
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
        tempTurret = turretToBuild;
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
        turretToBuild = tempTurret;
        nodeUI.Hide();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DeselectNode();
        }
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
