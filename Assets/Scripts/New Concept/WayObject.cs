using UnityEngine;

public class WayObject : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        print("collsion");
        // Check if the collider belongs to a Tile object
        Tile tile = other.gameObject.GetComponent<Tile>();
        if (tile != null)
        {
            // Disable the collider of the overlapping tile
            tile.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        print("collsion");
        // Check if the collider belongs to a Tile object
        Tile tile = other.GetComponent<Tile>();
        if (tile != null)
        {
            // Disable the collider of the overlapping tile
            tile.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
