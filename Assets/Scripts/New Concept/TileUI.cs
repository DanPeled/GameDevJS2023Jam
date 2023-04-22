using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TileUI : MonoBehaviour
{
    public GameObject ui;
    public TextMeshProUGUI upgradeCost, sellPrice, lvlText;
    private Tile target;
    public void SetTarget(Tile tile)
    {
        this.target = tile;
        transform.position = target.GetBuildPos();

        upgradeCost.text = "$" + target.currentBlueprint.upgradeCost * tile.upgradedLvl;
        sellPrice.text = "$" + target.currentBlueprint.GetSellAmount() * tile.upgradedLvl;
        lvlText.text = $"LVL: {tile.upgradedLvl}";

        upgradeCost.color = PlayerStats.money >= target.currentBlueprint.upgradeCost ? Color.white : Color.red;

        ui.SetActive(true);
    }
    public void Hide()
    {
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
