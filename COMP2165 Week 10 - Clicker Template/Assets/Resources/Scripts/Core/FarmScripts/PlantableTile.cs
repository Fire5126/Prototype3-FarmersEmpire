using COMP2165.Clicker;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlantableTile : MonoBehaviour, TickTimer, IPointerClickHandler
{
    public Vector2Int GridPosition { get; private set; }

    [SerializeField] private GameObject plantPrefab;
    private GameObject currentPlant;

    private enum TileState
    {
        Empty,
        Planted,
    }
    public void Initialise(Vector2Int gridPosition)
    {
        GridPosition = gridPosition;
    }

    public void PlantSeed(PlantData plantData)
    {
        if (currentPlant != null)
        {
            return;
        }
        
        if (SeedSelectionManager.Instance != null)
        {
            if (SeedSelectionManager.Instance.GetSelectedPlantData() != null)
            {
                PlantData selectedPlantData = SeedSelectionManager.Instance.GetSelectedPlantData();
                currentPlant = Instantiate(plantPrefab, transform.position, Quaternion.identity);
                currentPlant.GetComponent<Plant>().PlantType(selectedPlantData);
            }
        }

        Debug.Log($"Planted {plantData.name} at {GridPosition}");
    }

    public void Harvest()
    {
        if (currentPlant == null)
        {
            return;
        }
        Destroy(currentPlant);
        currentPlant = null;
    }

    public void Tick()
    {
        Debug.Log($"Ticking PlantableTile at {GridPosition}");
        if (currentPlant != null)
        {
            // Assuming the plant has a method to handle growth on tick
            currentPlant.GetComponent<Plant>().Grow();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            PlantSeed(SeedSelectionManager.Instance.GetSelectedPlantData());
        }
    }

}
