using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectibleScript : MonoBehaviour
{
    #region DoTween
    Transform targetObjectOnLeftForCollectible;
    public float doTweenSpeedInZAxis;
    public int hitPoints;
    bool collectibleStillInteactable;
    [HideInInspector]public int numberOfHits;

    #endregion


    private void Start()
    {
        collectibleStillInteactable = true;
        try
        {
        GetComponentInParent<MainGateScript>().maxCollected = hitPoints * 3;
        }
        catch (System.Exception)
        {
            Debug.LogError("Collectible must be children on MainGate with MainGateScript");
            throw;
        }

        targetObjectOnLeftForCollectible = GameObject.FindGameObjectWithTag("MovingTrails").transform;
    }


    public void DoPlayerInteract()
    {
        if (collectibleStillInteactable)
        {
        DoCollectiblesJourney();
        }

    }

    public void CollectibleChanger()
    {
        StartCoroutine(CollectibleChange());
    }

    IEnumerator CollectibleChange()
    {
        yield return new WaitForEndOfFrame();       
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + GameData.weaponIndex);
 
        if (GameData.weaponIndex < 3)
        {
            transform.Find("collectible1").gameObject.SetActive(true);
            transform.Find("collectible2").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("collectible2").gameObject.SetActive(true);
            transform.Find("collectible1").gameObject.SetActive(false);
        }
    }

    public void DoBulletInteract()
    {
        if (collectibleStillInteactable)
        {
        numberOfHits = Mathf.Clamp(numberOfHits+1, 0, hitPoints);
            if (GameData.weaponIndex<3)
            {
        transform.GetChild(numberOfHits - 1).gameObject.SetActive(true);
            }
            else
            {
                // this is for atm
                transform.DOShakeScale(0.1f, 0.2f, 5, 1f);
            }
    
        if(hitPoints == numberOfHits) {DoCollectiblesJourney();}
        Debug.Log(numberOfHits + " kere vuruldu");
        }


    }









    public void DoCollectiblesJourney()
    {
        collectibleStillInteactable = false;
        GetComponentInParent<MainGateScript>().DoMainGateCollectibleAction(numberOfHits);
        StartCoroutine(CollectiblesJourney());
    }

    IEnumerator CollectiblesJourney()
    {



        transform.DOMoveX(targetObjectOnLeftForCollectible.position.x, 0.6f);

        yield return new WaitForSecondsRealtime(0.65f);
        //  transform.DOMoveZ(ParentObjectForCollectible.position.z, (ParentObjectForCollectible.position.z - transform.position.z)*doTweenSpeedInZAxis );
        transform.DOMoveZ(transform.parent.position.z, (transform.parent.position.z - transform.position.z) / doTweenSpeedInZAxis);
        // ************************************************************** THERE WILL BE MAIN GATE EVENT


    }



}
