using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;
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
    void Start()
    {
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        ClearGrid();
        tiles = new Dictionary<Vector2, Tile>();
        string[] objects = mapString.Split(",");
        int count = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.transform.parent = map.transform;
                spawnedTile.name = $"Tile ({x}, {y})";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);


                tiles[new Vector2(x, y)] = spawnedTile;
                count++;
                if (count >= objects.Length)
                {
                    continue;
                }
                Instantiate(GetPiece(objects[count]), new Vector3(x, y), Quaternion.identity).transform.parent = map.transform;
            }
        }

        cam.transform.position = new Vector3((float)width / 2f - 0.5f, (float)height / 2 - 0.5f, -10);
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