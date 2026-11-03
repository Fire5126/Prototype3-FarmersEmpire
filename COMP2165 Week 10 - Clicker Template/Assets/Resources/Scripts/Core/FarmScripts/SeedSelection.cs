using COMP2165.Clicker;
using UnityEngine;

public class SeedSelection : MonoBehaviour
{
    private PlantData selectedPlantData;
    private SeedSelectionManager seedSelectionManager;

    private void Start()
    {
        seedSelectionManager = SeedSelectionManager.Instance;
    }

    public void SetSelectedPlantData(PlantData plantData)
    {
        selectedPlantData = plantData;
    }

    public void OnSeedSelected()
    {
        if (seedSelectionManager != null && selectedPlantData != null)
        {
            seedSelectionManager.SetSelectedPlantData(selectedPlantData);
        }
    }
}
