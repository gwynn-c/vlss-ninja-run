using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
    public GameEvents gameEvents;
    
    private void Awake() => Instance = this;

    private void OnEnable()
    {
        gameEvents = new GameEvents();
    }
    
    
}