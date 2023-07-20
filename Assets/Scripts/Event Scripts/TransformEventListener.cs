using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public TransformEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<Transform> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Transform b)
    {
        Response.Invoke(b);
    }
}
