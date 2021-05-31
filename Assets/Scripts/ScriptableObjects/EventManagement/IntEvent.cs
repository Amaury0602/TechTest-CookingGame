using System.Collections.Generic;
using UnityEngine;

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