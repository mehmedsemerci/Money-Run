using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformListEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public TransformListEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<List<Transform>> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(List<Transform> T)
    {
        Response.Invoke(T);

    }
}
