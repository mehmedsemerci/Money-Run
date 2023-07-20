using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Transform Event")]
public class TransformEvent : ScriptableObject
{
    private readonly List<TransformEventListener> eventListeners =
        new List<TransformEventListener>();

    public void Raise(Transform b)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(b);
    }

    public void RegisterListener(TransformEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(TransformEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
