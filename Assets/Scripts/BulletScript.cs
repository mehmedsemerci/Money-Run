using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;
public class BulletScript : MonoBehaviour
{
    public float bulletspeed, bulletRange;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gate"))
        {
        other.gameObject.GetComponent<GateScript>().DoBulletAction();
            gameObject.SetActive(false);
            other.transform.DOShakeScale(0.075f, 0.15f, 1, 10f);
            AudioManager.Instance.PlaySFX("BulletHit");
            MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            
        }

        else if (other.gameObject.CompareTag("ObjectWithHp"))
        {
            other.gameObject.GetComponent<ObjectHealthScript>().ReceiveDamage();
            gameObject.SetActive(false);
            other.transform.DOShakeScale(0.075f, 0.2f, 1, 10f);
            AudioManager.Instance.PlaySFX("BulletHit");
            MMVibrationManager.Haptic(HapticTypes.SoftImpact);


        }

        else if (other.gameObject.CompareTag("Collectible") )
        {
            other.gameObject.GetComponent<CollectibleScript>().DoBulletInteract();
            gameObject.SetActive(false);
            AudioManager.Instance.PlaySFX("BulletHit");
            MMVibrationManager.Haptic(HapticTypes.SoftImpact);

        }

    }

    private void OnEnable()
    {
        if (GameData.weaponIndex <3)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        StartCoroutine(BulletsJourney());
    }



    IEnumerator BulletsJourney()
    {
        yield return new WaitForSecondsRealtime(bulletRange * GameData.CalculateFireRANGE);
        gameObject.SetActive(false);
    }

    //public void PauseBulletLife()
    //{
    //    StopCoroutine(BulletsJourney());
    //}
    //public void UnpauseBulletLife()
    //{
    //    StartCoroutine(BulletsJourney());
    //}

    private void FixedUpdate()
    {
        if (GameManager.gameState == GameState.running)
        {
        gameObject.transform.Translate((new Vector3(0, 0, bulletspeed)) * Time.deltaTime);
        }

    }
}
