using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GateNumber {gate1, gate2, gate3 }
public class MainGatePartsScript : MonoBehaviour
{

public GateNumber gatenumber;
public TMP_Text expquantity;


    public void DoMainGatePartPlayerInteractAction()
    {
        int i;
        switch (gatenumber)
        {
            case GateNumber.gate1:
                i = 1;
                break;

            case GateNumber.gate2:
                i = 2;
                break;

            case GateNumber.gate3:
                i = 3;
                break;

            default:
                i = 0;
                Debug.LogError("somehow enums in gateparts dont work check theere");
                break;
        }

       bool succesfullyInteracted = transform.GetComponentInParent<MainGateScript>().GatePartAction(i);
        if (succesfullyInteracted)
        {
            AudioManager.Instance.PlaySFX("MainGateEnter");
            expquantity.color = Color.green;
        }

    }

    private void Start()
    {
        float expPerGateLevel = transform.GetComponentInParent<MainGateScript>().expPerGateLevel;

        switch (gatenumber)
        {
            case GateNumber.gate1:
                expquantity.text = "+ " + (expPerGateLevel*1) + "EXP";
                break;
            case GateNumber.gate2:
                expquantity.text = "+ " + (expPerGateLevel *2) + "EXP";
                break;
            case GateNumber.gate3:
                expquantity.text = "+ " + (expPerGateLevel * 3) + "EXP";
                break;
            default:
                break;
        }

    }




}
