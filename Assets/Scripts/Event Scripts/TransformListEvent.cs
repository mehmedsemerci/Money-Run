using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/TransformList Event")]
public class TransformListEvent : ScriptableObject
{
    private readonly List<TransformListEventListener> eventListeners =
       new List<TransformListEventListener>();

    public void Raise(List<Transform> T)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(T);

    }

    public void RegisterListener(TransformListEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(TransformListEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}
