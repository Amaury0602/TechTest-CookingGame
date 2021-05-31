using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event asset that you can reference in the inspector to trigger Listeners
/// Doesn't hold any payload
/// </summary>

[CreateAssetMenu(fileName = "New Base Event", menuName = "ScriptableObject/Event/BaseEvent")]
public class BaseEvent : ScriptableObject
{
    private List<BaseEventListener> listeners = new List<BaseEventListener>();
    public void RegisterListerner(BaseEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(BaseEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; --i)
        {
            listeners[i].RaiseEvent();
        }
    }
}
