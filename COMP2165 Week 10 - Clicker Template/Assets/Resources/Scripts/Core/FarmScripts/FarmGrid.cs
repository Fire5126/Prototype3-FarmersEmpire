using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FarmGrid : MonoBehaviour
{
    [SerializeField] private GameObject plantableTilePrefab;
    [SerializeField] private float tileSpacing = 1.0f;
    private Dictionary<Vector2Int, PlantableTile> plantableTiles = new Dictionary<Vector2Int, PlantableTile>();
    private int currentWidth;
    private int currentHeight;

    public void InitialiseFarm(int width, int height)
    {
        ExpandFarm(width, height);
    }

    public void ExpandFarm(int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2Int position = new Vector2Int(x * (int)tileSpacing, y * (int)tileSpacing);

                if (plantableTiles.ContainsKey(position))
                {
                    continue; 
                }

                GameObject tileObject = Instantiate(plantableTilePrefab, new Vector3(x * tileSpacing, y * tileSpacing, 0), Quaternion.identity, transform);
                PlantableTile tile = tileObject.GetComponent<PlantableTile>();
                tile.Initialise(position);
                plantableTiles.Add(position, tile);
            }
        }

        currentHeight = height;
        currentWidth = width;

    }
}
