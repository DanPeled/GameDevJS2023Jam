using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using System.Linq;
public class GridManager : MonoBehaviour
{
    public string mapString;
    [Header("Pieces")]
    public SerializedDictionary<string, GameObject> pieces;
    [Header("Map Size")]
    [SerializeField] private int width;
    [SerializeField] private int height;

    [Header("Refrences")]
    [SerializeField] private GameObject map;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> tiles;
    public GameObject[] ways;
    void Start()
    {
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        ClearGrid();
        tiles = new Dictionary<Vector2, Tile>();
        string[] objects = mapString.Split(",");
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
    }
    public void ColourAll()
    {
        GenerateGrid();
        foreach (Tile tile in tiles.Values)
        {
            float x = tile.transform.position.x, y = tile.transform.position.y;
            var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
            tile.Init(isOffset);
        }
    }
    public void Colour(float x, float y, Tile tile)
    {
        var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
        tile.Init(isOffset);
    }
    public Tile GetTileAtPos(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        else return null;
    }
    public void Spawn(GameObject obj, Vector3 pos)
    {
        Instantiate(obj, pos, Quaternion.identity);
    }
    public GameObject GetPiece(string pieceString)
    {
        GameObject piece = new GameObject();
        if (pieces.ContainsKey(pieceString))
        {
            piece = pieces[pieceString];
        }
        else
        {
            // special pieces / blank
            switch (pieceString)
            {
                case "_":
                    piece = null;
                    break;
            }
        }
        return piece;
    }
    public void ClearGrid()
    {
        while (map.transform.childCount > 0)
        {
            DestroyImmediate(map.transform.GetChild(0).gameObject);
        }
    }
}