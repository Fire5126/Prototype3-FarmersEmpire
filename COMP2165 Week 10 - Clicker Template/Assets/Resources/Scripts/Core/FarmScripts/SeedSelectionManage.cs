using COMP2165.Clicker;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SeedSelectionManager : MonoBehaviour
{
    public static SeedSelectionManager Instance { get; private set; }

    [SerializeField] private GameObject seed;
    [SerializeField] private float tileSpacing = 1.0f;
    private Dictionary<string, SeedSelection> seedSelectionHolder = new Dictionary<string, SeedSelection>();
    private PlantData selectedPlantData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSelectedPlantData (PlantData plantData)
    {
        selectedPlantData = plantData;
    }

    public void ClearSelection()
    {
        selectedPlantData = null;
    }

    public PlantData GetSelectedPlantData()
    {
        return selectedPlantData;
    }

    public void SetSeedSelection(List<PlantData> plantData)
    {
        for (int x = 0; x < plantData.Count; x++)
        {
            if (seedSelectionHolder.ContainsKey(plantData[x].id))
            {
                return;
            }

            GameObject tileObject = Instantiate(seed, new Vector3(x * tileSpacing, 0, 0), Quaternion.identity, transform);
            SeedSelection tile = tileObject.GetComponent<SeedSelection>();
            tile.SetSelectedPlantData(plantData[x]);
            seedSelectionHolder.Add(plantData[x].id, tile);

        }
    }
}
