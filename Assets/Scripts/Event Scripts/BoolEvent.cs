using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Bool Event")]
public class BoolEvent : ScriptableObject
{
    private readonly List<BoolEventListener> eventListeners =
        new List<BoolEventListener>();

    public void Raise(bool b)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(b);
    }

    public void RegisterListener(BoolEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(BoolEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
