using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public GameObject buildEffect;
    public Vector2 offset;
    [SerializeField] private Color baseColor, offsetColor, normalHighlightColor, noMoneyColor;
    public GameObject turret;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    private bool isOffset;
    private SpriteRenderer highlightRenderer;
    [HideInInspector]
    public TurretBlueprint currentBlueprint;
    public int upgradedLvl = 1;

    void OnValidate()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = isOffset ? offsetColor : baseColor;
        }
    }

    void Awake()
    {
        highlightRenderer = highlight.GetComponent<SpriteRenderer>();
    }



    public Vector2 GetBuildPos()
    {
        return transform.position + (Vector3)offset;
    }

    public void Init(bool isOffset)
    {
        this.isOffset = isOffset;
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    public void Init()
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    void OnMouseEnter()
    {
        if (!BuildManager.i.CanBuild) return;
        if (BuildManager.i.HasMoney)
        {
            highlightRenderer.color = normalHighlightColor;
        }
        else
        {
            highlightRenderer.color = noMoneyColor;
        }
        highlight.SetActive(true);
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.price)
        {
            Debug.Log("not enough money");
            return;
        }
        var effect = Instantiate(buildEffect, transform.position, Quaternion.identity);

        Debug.Log($"built {blueprint.prefab.name}");
        PlayerStats.money -= blueprint.price;
        currentBlueprint = blueprint;

        // build a turret
        GameObject turret = Instantiate(blueprint.prefab, new Vector3(this.GetBuildPos().x, this.GetBuildPos().y, 0), this.transform.rotation);
        AudioManager.i.PlaySFX("build");
        this.turret = turret;

        Destroy(effect, 2);
    }
    public void UpdgradeTurret()
    {
        if (PlayerStats.money < (currentBlueprint.upgradeCost * upgradedLvl))
        {
            return;
        }
        PlayerStats.money -= (currentBlueprint.upgradeCost * upgradedLvl);
        // upgrade
        upgradedLvl++;
        turret.GetComponent<Turret>().Upgrade(upgradedLvl);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // Check if there are any colliders on top of this tile's collider
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return;
            }
        }

        if (!BuildManager.i.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            BuildManager.i.SelectNode(this);
            return;
        }

        BuildTurret(BuildManager.i.GetTurretToBuild());
    }
    public void SellTurret()
    {
        PlayerStats.money += (currentBlueprint.GetSellAmount() * upgradedLvl);

        upgradedLvl = 1;

        Destroy(turret);
        currentBlueprint = null;
    }
}
