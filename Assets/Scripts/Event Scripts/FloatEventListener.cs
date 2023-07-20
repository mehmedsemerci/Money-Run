using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public FloatEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<float> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(float x)
    {
        Response.Invoke(x);
    }
}
