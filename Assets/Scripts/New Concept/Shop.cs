using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standardTurret, missleLauncher, laserBeamer, alternateStandard;
    public TextMeshProUGUI standardtext, missletext, laserbeamertext, alternateStandardText;
    public GameObject turretChosen;
    void Start()
    {
        buildManager = BuildManager.i;
        standardtext.text = $"${standardTurret.price}";
        //missletext.text = $"${missleLauncher.price}";
        laserbeamertext.text = $"${laserBeamer.price}";
    }
    void Update()
    {
        if (standardtext != null)
        {
            standardtext.color = PlayerStats.money >= standardTurret.price ? Color.white : Color.red;
            standardtext.transform.parent.parent.GetComponent<Button>().interactable = PlayerStats.money >= standardTurret.price;
        }
        if (missletext != null)
        {
            missletext.color = PlayerStats.money >= missleLauncher.price ? Color.white : Color.red;
            missletext.transform.parent.parent.GetComponent<Button>().interactable = PlayerStats.money >= missleLauncher.price;
        }
        if (laserbeamertext != null)
        {
            laserbeamertext.color = PlayerStats.money >= laserBeamer.price ? Color.white : Color.red;
            laserbeamertext.transform.parent.parent.GetComponent<Button>().interactable = PlayerStats.money >= laserBeamer.price;
        }
        if (alternateStandardText != null)
        {
            alternateStandardText.color = PlayerStats.money >= alternateStandard.price ? Color.white : Color.red;
            alternateStandardText.transform.parent.parent.GetComponent<Button>().interactable = PlayerStats.money >= alternateStandard.price;
        }
        turretChosen.SetActive(buildManager.GetTurretToBuild() != null);
    }
    public void SelectStandardTurret()
    {
        if (PlayerStats.money >= standardTurret.price)
            buildManager.SelectTurretToBuild(standardTurret);
        turretChosen.transform.position = standardtext.transform.parent.parent.transform.position;
        turretChosen.GetComponent<RectTransform>().sizeDelta = standardtext.transform.parent.parent.GetComponent<RectTransform>().sizeDelta;

    }
    public void SelectAltStandardTurret()
    {
        if (PlayerStats.money >= alternateStandard.price)
            buildManager.SelectTurretToBuild(alternateStandard);
        turretChosen.transform.position = alternateStandardText.transform.parent.parent.transform.position;
        turretChosen.GetComponent<RectTransform>().sizeDelta = alternateStandardText.transform.parent.parent.GetComponent<RectTransform>().sizeDelta;
    }
    public void SelectMissleLauncher()
    {
        buildManager.SelectTurretToBuild(missleLauncher);
        turretChosen.transform.position = missletext.transform.parent.parent.transform.position;
        turretChosen.GetComponent<RectTransform>().sizeDelta = missletext.transform.parent.parent.GetComponent<RectTransform>().sizeDelta;
    }
    public void SelectLaserBeamer()
    {
        if (PlayerStats.money >= laserBeamer.price)
            buildManager.SelectTurretToBuild(laserBeamer);
        turretChosen.transform.position = laserbeamertext.transform.parent.parent.transform.position;
        turretChosen.GetComponent<RectTransform>().sizeDelta = laserbeamertext.transform.parent.parent.GetComponent<RectTransform>().sizeDelta;
    }
}
