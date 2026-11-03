using COMP2165.Clicker;
using UnityEngine;


public class Plant : MonoBehaviour
{
    private PlantData plantType;
    private int tickTime;
    private SpriteRenderer spriteRenderer;
    private Collider2D plantCollider;

    private PlantState currentState;
    private enum PlantState
    {
        Seed,
        Growing,
        Grown
    }

    private void Start()
    {
        currentState = PlantState.Seed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        plantCollider = GetComponent<Collider2D>();
    }

    public void PlantType(PlantData plantType)
    {
        this.plantType = plantType;
        tickTime = Mathf.RoundToInt(plantType.seedLifeTime);
    }

    public void Grow()
    {
        if (tickTime <= 0)
        {
            switch (currentState)
            {
                case PlantState.Seed:
                    currentState = PlantState.Growing;
                    tickTime = Mathf.RoundToInt(plantType.adolescentLifeTime);
                    break;
                case PlantState.Growing:
                    currentState = PlantState.Grown;
                    tickTime = Mathf.RoundToInt(plantType.adolescentLifeTime);
                    break;
                case PlantState.Grown:
                    Destroy(gameObject);
                    break;
            }
        }
        else
        {
            tickTime--;
        }

        Debug.Log($"Plant state: {currentState}, Tick time: {tickTime}");
    }
}
