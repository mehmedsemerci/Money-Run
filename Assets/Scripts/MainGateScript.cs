using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MainGateScript : MonoBehaviour
{
    [HideInInspector]public float maxCollected;
    private float totalCollected;
    public bool gate1Usable, gate2Usable, gate3Usable;
    public float expPerGateLevel;
    public GameObject piston, dollarRollsParent, machine;
    private void Start()
    {
        if (maxCollected ==0)
        {
            maxCollected = 15;
        }
        if (expPerGateLevel ==0)
        {
            expPerGateLevel = 35;
        }
    }

    public void DoMainGateCollectibleAction(int totalhit)
    {
        totalCollected += totalhit;
        
        StartCoroutine(PistonAnims());
        StartCoroutine(DollarAnims(totalhit));

        // if position or activiness of dollars is not right check those anims

        float collectpercentage = totalCollected / maxCollected;

        if (collectpercentage >= 0.33)
        {
            Debug.Log(collectpercentage + " TOPLANMA YUZDESI");
            gate1Usable = true;
            if (collectpercentage >= 0.66)
            {
                gate2Usable = true;

                if (collectpercentage ==1)
                {
                    gate3Usable = true;
                }
            }

        }

    }

    public bool GatePartAction(int gatenumber) 
    {
        switch (gatenumber)
        {
            case 1:
                gate2Usable = false;
                gate3Usable = false;
                if (gate1Usable)
                {
                    finalGateResult(gatenumber, expPerGateLevel);
                    return true;
                }
                return false;
                break;
            case 2:
                gate1Usable = false;
                gate3Usable = false;
                if (gate2Usable)
                {
                    finalGateResult(gatenumber, expPerGateLevel);
                    return true;
                }
                return false;
                break;
            case 3:
                gate1Usable = false;
                gate2Usable = false;
                if (gate3Usable)
                {
                    finalGateResult(gatenumber, expPerGateLevel);
                    return true;
                }
                return false;
                break;
            default:
                return false;
                break;

        }


    }


        private void finalGateResult(int gatenumber, float expPerGateLevel)
        {
        GameData.CalculateWeaponExp(expPerGateLevel * gatenumber);
        Debug.Log(gatenumber);
        SetDollarsActiveOrNot(gatenumber);


        }


    IEnumerator PistonAnims()
    {
        machine.transform.DOShakeRotation(0.1f, 0.2f, 5, 10f);
        piston.transform.DOMoveX(piston.transform.position.x + 3f, 0.2f);
        yield return new WaitForSecondsRealtime(0.3f);

        piston.transform.DOMoveX(piston.transform.position.x - 3f, 0.2f);
    }

    IEnumerator DollarAnims(int totalhit)
    {
        for (int i = (int)totalCollected-totalhit; i < totalCollected; i++)
        {
            yield return new WaitForFixedUpdate(); yield return new WaitForFixedUpdate();
            dollarRollsParent.transform.Translate(Vector3.right * (0.46f));
            dollarRollsParent.transform.GetChild(i).gameObject.SetActive(true);
        }

    }

    private void SetDollarsActiveOrNot(int gatenumber ) 
    {

        switch (gatenumber)
        {
            case 1:
                for (int i = (int)totalCollected-1; i >= totalCollected-5; i--)
                {
                    transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                }
                break;
            case 2:
                for (int i = (int)totalCollected-6; i >= (int)totalCollected-10; i--)
                {
                    transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                }
                break;
            case 3:
                for (int i = (int)totalCollected-11; i >= totalCollected-15; i--)
                {
                    transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                }
                break;

            default:
                break;



        }

    
    }


    }





