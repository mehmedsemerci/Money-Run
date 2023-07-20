using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GateType { Firerate, Firerange, Weaponexp }

public class GateScript : MonoBehaviour
{
    public TMP_Text typeText, increaseRateText, quantityText;
    public GateType gateType;
    public float increaseRate, quantity;
    public FloatEvent fireRATEGateEvents,fireRANGEGateEvents; //firerange will be lifespan of the bullet so it will go further
    public bool isGateBarricated;
    [SerializeField] bool DestroyParentTooForDoubleGates;
    public Material possitiveGateMaterial,negativeGateMaterial,possitiveGateEdgeMaterial,negativeGateEdgeMaterial;

    

    private void OnEnable()
    {
        switch (gateType)
        {
            case GateType.Firerate:
                typeText.text = "RATE";
                break;
            case GateType.Firerange:
                typeText.text = "RANGE";
                break;
            case GateType.Weaponexp:
                typeText.text = "EXP";
                break;
            default:
                break;
        }

        increaseRateText.text = increaseRate.ToString();
        quantityText.text = quantity.ToString();
        MaterialCheck();
    }



    public void GateAction() // this will triggered by player
    {
        if (!isGateBarricated)
        {
        switch (gateType)
        {
            case GateType.Firerate:
                Debug.Log("FireRate was:" + GameData.CalculateFireRATE);
                GameData.CalculateFireRATE = quantity / 100;
                Debug.Log("Now FireRate is:" + GameData.CalculateFireRATE);
                break;
            case GateType.Firerange:
                Debug.Log("FireRange was:" + GameData.CalculateFireRATE);
                GameData.CalculateFireRANGE = quantity / 100;
                Debug.Log("Now FireRange is:" + GameData.CalculateFireRATE);
                break;
                case GateType.Weaponexp:
                    GameData.CalculateWeaponExp(quantity);
                    break;
                default:
                break;
        }
            if (DestroyParentTooForDoubleGates)
            {
                gameObject.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }


        }

    }

    private void MaterialCheck()
    {
        if (quantity >= 0)
        {
            gameObject.GetComponent<Renderer>().material = possitiveGateMaterial;
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                transform.GetChild(0).GetChild(i).GetComponent<Renderer>().material = possitiveGateEdgeMaterial;
            }

        }
        else
        {
            gameObject.GetComponent<Renderer>().material  = negativeGateMaterial;
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                transform.GetChild(0).GetChild(i).GetComponent<Renderer>().material = negativeGateEdgeMaterial;
            }
        }


    }
        
        

    public void DoBulletAction()
    {
        if (!isGateBarricated)
        {
        quantity += increaseRate;
        quantityText.text = quantity.ToString();
            MaterialCheck();
        }

    }


}
