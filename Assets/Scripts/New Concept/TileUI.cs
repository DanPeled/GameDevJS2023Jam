using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUI : MonoBehaviour
{
    public GameObject ui;
    private Tile target;
    public void SetTarget(Tile tile){
        this.target = tile;
        transform.position = target.GetBuildPos();
        ui.SetActive(true);
    }
    public void Hide(){
        ui.SetActive(false);
    }
}
