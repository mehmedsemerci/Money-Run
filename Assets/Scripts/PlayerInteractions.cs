using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {

            other.GetComponent<GateScript>().GateAction();
        }
        else if (other.CompareTag("Collectible"))
        {
            other.GetComponent<CollectibleScript>().DoPlayerInteract();
         //   AudioManager.Instance.PlaySFX("collectible");
        }
        else if (other.CompareTag("Hazard") || other.CompareTag("ObjectWithHp"))
        {

            other.GetComponent<HazardScript>().DoHazardAction();
        }
        else if (other.CompareTag("Dollar"))
        {
            other.GetComponent<DollarScript>().DoDollarAction();
        }
        else if (other.CompareTag("FinishLine"))
        {
            other.GetComponent<FinishLine>().DoFinish();
        }

        else if (other.CompareTag("CollectibleRelatedGate"))
        {
            // Dont forget, you should never interact with mainGateScript, interact with MainGatePartScript
            other.GetComponent<MainGatePartsScript>().DoMainGatePartPlayerInteractAction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hazard") || other.CompareTag("ObjectWithHp"))
        {

            other.GetComponent<HazardScript>().DoHazardExit();
        }
    }




}
