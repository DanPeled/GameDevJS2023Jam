using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using System.Linq;
public class GridManager : MonoBehaviour
{
    [Header("Map Size")]
    [SerializeField] private int width;
    [SerializeField] private int height;

    [Header("Refrences")]
    [SerializeField] private GameObject map;
    [SerializeField] private Tile tilePrefab;

    private Dictionary<Vector2, Tile> tiles;
    public GameObject[] ways;
    public Camera cam;
    public Vector3 camOffset;
    void Start()
    {
        cam = Camera.main;
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        ClearGrid();
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.transform.parent = map.transform;
                spawnedTile.name = $"Tile ({x}, {y})";
                Colour(x, y, spawnedTile);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        cam.transform.position = new Vector3((float)width / 2f - 0.5f, (float)height / 2 - 0.5f, -10) + camOffset;
    }

    public void Colour(float x, float y, Tile tile)
    {
        var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
        tile.Init(isOffset);
    }

    public void ClearGrid()
    {
        while (map.transform.childCount > 0)
        {
            DestroyImmediate(map.transform.GetChild(0).gameObject);
        }
    }
}