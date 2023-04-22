using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int price;

    public int upgradeCost;

    public int GetSellAmount()
    {
        return price / 2;
    }
}