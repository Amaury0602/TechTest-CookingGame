using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Add this script to a GameObject if it should listen to an event with a Vector3 payload.
/// </summary>
[System.Serializable]
public class LocalEventListener : MonoBehaviour
{
    // The game event instance to register to.
    [Header("Event to Listen to")]
    [SerializeField] private LocalEvent LocalEvent;
    // The unity event responce created for the event.
    [SerializeField] private UnityEvent<Vector3> Response;

    private void OnEnable()
    {
        LocalEvent.RegisterListerner(this);
    }

    private void OnDisable()
    {
        LocalEvent.UnregisterListener(this);
    }

    public void RaiseEvent(Vector3 position)
    {
        Response.Invoke(position);
    }
}