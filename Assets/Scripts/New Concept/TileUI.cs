using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TileUI : MonoBehaviour
{
    public GameObject ui;
    public TextMeshProUGUI upgradeCost, sellPrice;
    private Tile target;
    public void SetTarget(Tile tile)
    {
        this.target = tile;
        transform.position = target.GetBuildPos();

        upgradeCost.text = "$" + target.currentBlueprint.upgradeCost * tile.upgradedLvl;
        sellPrice.text = "$" + target.currentBlueprint.GetSellAmount() * tile.upgradedLvl;
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpdgradeTurret();
        BuildManager.i.DeselectNode();
    }
    public void Sell(){
        target.SellTurret();
        BuildManager.i.DeselectNode();
    }
}
