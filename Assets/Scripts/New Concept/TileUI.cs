using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TileUI : MonoBehaviour
{
    public SpriteRenderer rangeObject;
    public GameObject ui;
    public Vector2 upPos, downPos;
    public TextMeshProUGUI upgradeCost, sellPrice, lvlText;
    private Tile target;
    public void SetTarget(Tile tile)
    {
        rangeObject.enabled = true;
        rangeObject.transform.position = tile.GetBuildPos();
        if (tile.turret != null && tile.turret.GetComponent<Turret>() != null)
            rangeObject.GetComponent<CircleResizer>().radius = tile.turret.GetComponent<Turret>().range;
        this.target = tile;
        transform.position = target.GetBuildPos();

        ui.transform.localPosition = tile.transform.localPosition.y < 0.9977493 ? upPos : downPos;

        upgradeCost.text = "$" + target.currentBlueprint.upgradeCost * tile.upgradedLvl;
        sellPrice.text = "$" + target.currentBlueprint.GetSellAmount() * tile.upgradedLvl;
        lvlText.text = $"LVL: {tile.upgradedLvl}";
        if (tile.turret != null && tile.turret.GetComponent<Turret>() != null)
            upgradeCost.color = PlayerStats.money >= tile.turret.GetComponent<Turret>().upgradeCost ? Color.white : Color.red;

        ui.SetActive(true);
    }
    public void Hide()
    {
        rangeObject.enabled = false;
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        int level = target.upgradedLvl;
        lvlText.text = $"LVL: {target.upgradedLvl}";
        target.UpdgradeTurret();
        if (level != target.upgradedLvl)
            BuildManager.i.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.i.DeselectNode();
    }
}
