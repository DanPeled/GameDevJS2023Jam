using UnityEngine;
using UnityEngine.EventSystems;
public class Tile : MonoBehaviour
{
    public Vector2 offset;
    [SerializeField] private Color baseColor, offsetColor, normalHighlightColor, noMoneyColor;
    public GameObject turret;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    private bool isOffset;
    private SpriteRenderer highlightRenderer;
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
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
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

        BuildManager.i.BuildTurretOn(this);
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
        GameLoop.i.currentTile = transform.position;
    }
    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}