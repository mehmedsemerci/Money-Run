using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunChangerScript : MonoBehaviour
{
    public GameObject[] weapons;
    public int requiredLevelForNextWeapon;
    public VoidEvent AmmoAndCollectibleChangerEvent;
    private void Awake()
    {
       // ChangeWeapon(0);
        CheckWeapon();
    }
    public void CheckWeapon()
    {
        int weaponIndex;
        int weaponLevel = (int)GameData.weaponLevel;
        if (weaponLevel != 0)
        {
        weaponIndex = (int)weaponLevel / requiredLevelForNextWeapon;
        }
        else
        {
        weaponIndex = 0;
        }

        if (weapons.Length !=0 && weapons.Length > weaponIndex){ChangeWeapon(weaponIndex);}
        GameData.weaponIndex = weaponIndex;// this will be here because weapon wont change if out of bond
    }

    // fix that you can only lose 1 level even if you suppused to lose more, laterr


    private void ChangeWeapon(int weaponIndex)
    {
        Debug.Log("triying for: " + weaponIndex + " index numbered weapon");
        foreach (GameObject item in weapons)
        {
            item.SetActive(false);

        }
        weapons[weaponIndex].SetActive(true);

        AmmoAndCollectibleChangerEvent.Raise();
    }





}
