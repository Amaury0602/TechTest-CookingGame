using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event asset that you can reference in the inspector to trigger Listeners
/// Holds an integer payload
/// </summary>
[CreateAssetMenu(fileName = "New Int Event", menuName = "ScriptableObject/Event/IntEvent")]

public class IntEvent : ScriptableObject
{
    private List<IntEventListener> listeners = new List<IntEventListener>();
    public void RegisterListerner(IntEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(IntEventListener listener)
    {
        listeners.Remove(listener);
    }

    public void Raise(int num)
    {
        for (int i = listeners.Count - 1; i >= 0; --i)
        {
            listeners[i].RaiseEvent(num);
        }
    }
}