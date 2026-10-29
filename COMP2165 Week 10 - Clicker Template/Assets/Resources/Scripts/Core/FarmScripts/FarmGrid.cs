using UnityEngine;

public class FarmGrid : MonoBehaviour
{
    [SerializeField] private GameObject plantableTilePrefab;
    private PlantableTile[] plantableTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plantableTiles = gameObject.GetComponentsInChildren<PlantableTile>();
        Debug.Log("Number of plantable tiles: " + plantableTiles.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
