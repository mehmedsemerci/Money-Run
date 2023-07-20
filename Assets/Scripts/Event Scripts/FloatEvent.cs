using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Float Event")]
public class FloatEvent : ScriptableObject
{
    private readonly List<FloatEventListener> eventListeners =
        new List<FloatEventListener>();

    public void Raise(float x)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(x);
    }

    public void RegisterListener(FloatEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(FloatEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

}
