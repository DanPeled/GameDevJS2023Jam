using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public Vector2 currentTile;
    public static GameLoop i;

    void Awake()
    {
        i = this;
    }
}