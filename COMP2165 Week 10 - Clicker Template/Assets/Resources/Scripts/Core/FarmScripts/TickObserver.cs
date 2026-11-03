using System.Linq;
using UnityEngine;

public class TickObserver : MonoBehaviour
{
    private static TickObserver instance;

    [SerializeField] private float setInterval = 1.0f;
    private float tickInterval; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        tickInterval = setInterval;
    }

    // Update is called once per frame
    void Update()
    {
        tickInterval -= Time.deltaTime;

        if (tickInterval <= 0)
        {
            tickInterval = setInterval;
            Tick();
        }
    }

    private void Tick()
    {
        TickTimer[] tickTimers = Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
            .OfType<TickTimer>()
            .ToArray();

        foreach (TickTimer tickTimer in tickTimers)
        {
            tickTimer.Tick();
        }
    }

    public void ModifyTickTimer(float modifier)
    {
        tickInterval += modifier;
    }
}
