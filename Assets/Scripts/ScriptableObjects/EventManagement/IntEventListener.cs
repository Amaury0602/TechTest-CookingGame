using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Add this script to a GameObject if it should listen to a an event with an integer payload.
/// </summary>
[System.Serializable]
public class IntEventListener : MonoBehaviour
{
    // The game event instance to register to.
    [Header("Event to Listen to")]
    [SerializeField] private IntEvent IntEvent;
    // The unity event responce created for the event.
    [SerializeField] private UnityEvent<int> Response;

    private void OnEnable()
    {
        IntEvent.RegisterListerner(this);
    }

    private void OnDisable()
    {
        IntEvent.UnregisterListener(this);
    }

    public void RaiseEvent(int num)
    {
        Response.Invoke(num);
    }
}
