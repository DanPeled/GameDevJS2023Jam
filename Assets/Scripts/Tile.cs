using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    void OnValidate()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = baseColor;
        }
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