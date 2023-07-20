using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public enum HpObjectType {PiggyBank, GateBarricade /* , Collectible */}
public class ObjectHealthScript : MonoBehaviour
{
    [SerializeField]private float hp;
    private bool isDead = false;
    public HpObjectType hpObjectType;
    public TMP_Text pigHP;

    #region DoTween
    Transform targetObjectOnLeftForCollectible;
    public float doTweenSpeedInZAxis;
    #endregion

    public float Hp 
    {
        get 
        { 
            return hp; 
        }
        set 
        { 
            if(value>= hp){hp = 0; isDead = true; }
            else { hp -= value; }
        }
    }

    public void ReceiveDamage()
    {
 
        switch (hpObjectType)
        {
            case HpObjectType.PiggyBank:
                PiggyBackReceiveDamageAnims();
                Hp = GameData.CalculateDamage();
                if (hp>0){pigHP.text = ((int)hp).ToString();}

                break;
            case HpObjectType.GateBarricade:
                Hp = GameData.CalculateDamage(); // damage will be calculated due to weapon level
                Debug.Log(Hp);
                break;

            default:
                break;
        }
        if (isDead) { WhenObjectDies(); }

    }

    private void WhenObjectDies()
    {
        switch (hpObjectType)
        {
            case HpObjectType.PiggyBank:
                pigHP.text = "";
                Instantiate(Resources.Load<GameObject>("Prefabs/Dollar"),transform.position-Vector3.up*0.75f, Quaternion.Euler(-90f, 0f, 0f));
                Destroy(gameObject.GetComponent<BoxCollider>());
                transform.GetChild(0).gameObject.SetActive(false);
                PiggyBankDestroyAnims();

                break;
            case HpObjectType.GateBarricade:
                GetComponentInParent<GateScript>().isGateBarricated = false;
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    private void PiggyBackReceiveDamageAnims()
    {
        int i = Random.Range(0, transform.GetChild(1).gameObject.transform.childCount); // there are 12 child of pig, change this if you change model
        transform.Find("PigParticles1").gameObject.transform.GetChild(i).gameObject.SetActive(true);
        transform.Find("PigParticles1").gameObject.transform.GetChild(i).DOScale(Vector3.zero, 3f);
    }
    private void PiggyBankDestroyAnims()
    {
        transform.Find("PigParticles2").gameObject.SetActive(true);
        for (int i = 0; i < transform.Find("PigParticles2").childCount; i++)
        {
            transform.Find("PigParticles2").GetChild(i).DOScale(Vector3.zero, 3f);
        }


    }


    private void Start()
    {
        if (hpObjectType == HpObjectType.GateBarricade)
        {
        GetComponentInParent<GateScript>().isGateBarricated = true;
        }
        else if (hpObjectType == HpObjectType.PiggyBank)
        {
         //   pigHP.text = ((int)hp).ToString();

        }


    }
    //private void Awake()
    //{
    //    if (hpObjectType == HpObjectType.PiggyBank)
    //    {
    //              pigHP.text = ((int)hp).ToString();

    //    }
    //}

    //this is buggy for some reason look later
}
