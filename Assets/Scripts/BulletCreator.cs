using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletCreator : MonoBehaviour
{
    GameObject poolingObject;
    public Transform bulletSpawnPoint;

    void Start()
    {
        poolingObject = GameObject.FindGameObjectWithTag("PoolingObject");
        if (poolingObject == null)
        {
            Debug.LogError("Define the pooling object on bullet creator");
        }
        StartCoroutine(RepeatFire());
    }



    IEnumerator RepeatFire()
    {

        yield return new WaitForSecondsRealtime(1/(GameData.CalculateFireRATE));
        if (GameManager.gameState == GameState.running)
        {
        poolingObject.GetComponent<BulletPoolScript>().GetPooledBullet().transform.position = bulletSpawnPoint.position;
            if (GameData.weaponLevel !=0)
            {
                StartCoroutine(ShakeWeapon());
            }
            else
            {
                transform.Find("Guns").Find("Gun0").Find("Weapon0").GetComponent<Animator>().SetTrigger("CoinToss");
            }

        }
        StartCoroutine(RepeatFire());
    }

    IEnumerator ShakeWeapon()
    {
        transform.Find("Guns").transform.DOShakeRotation((0.8f / GameData.CalculateFireRATE), 10f, 4, 1);
        yield return new WaitForSecondsRealtime(0.8f);
        transform.Find("Guns").transform.eulerAngles = Vector3.zero;
    }



}
