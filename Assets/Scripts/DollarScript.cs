using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarScript : MonoBehaviour
{
    public int Quantity;
    public VoidEvent TextUpdateEvent;

    public void DoDollarAction()
    {
        GameData.CalculateDollars = Quantity;
        TextUpdateEvent.Raise();
        gameObject.SetActive(false);

    }



}
