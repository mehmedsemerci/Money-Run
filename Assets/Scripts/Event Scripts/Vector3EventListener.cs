using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Vector3EventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public Vector3Event Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<Vector3> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Vector3 vec3)
    {
        Response.Invoke(vec3);
    }
}
