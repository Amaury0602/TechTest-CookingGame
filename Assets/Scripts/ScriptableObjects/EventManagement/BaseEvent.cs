using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Event that you can create as an asset and place in "Assets/GameEvents" folder. Reference it inside a script and call the Raise 
/// function to trigger all the Base Event Listeners.
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
