using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Add this script to a GameObject if it should listen to a base event (without payload). 
/// </summary>

public class BaseEventListener : MonoBehaviour
{
    // The game event instance to register to.
    [Header("Event to Listen to")]
    [SerializeField] private BaseEvent BaseEvent;
    // The unity event response created for the event.
    [SerializeField] private UnityEvent Response;

    private void OnEnable()
    {
        BaseEvent.RegisterListerner(this);
    }

    private void OnDisable()
    {
        BaseEvent.UnregisterListener(this);
    }

    public void RaiseEvent()
    {
        Response.Invoke();
    }
}
