using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    private GameObject turret;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    void OnValidate()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = baseColor;
        }
    }
    void OnMouseDown()
    {
        if (turret != null){
            Debug.Log("Cant build there - TODO: Display on screen");
            return;
        }
        // build a turret
    }
    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
        GameLoop.i.currentTile = transform.position;
    }
    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}