using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    #region stored data
    public static int fireRATEUpgradeLevel, weaponUpgradeLevel, fireRANGEUpgradeLevel, incomeUpgradeLevel;
    internal static float totalDollars;
    #endregion

    #region level based data
    static float calculateFireRATE, weaponExp, calculateFireRANGE;
    public static float globalMoveSpeedMultiplier, weaponLevel;
    public static float weaponIndex; // this will be controlled by GunChangerScript
    public float baseFireRate, baseFireRange;
    public static VoidEvent CheckWeaponEvent;
    #endregion
    public static float CalculateFireRATE 
    {
        get {return Mathf.Clamp((calculateFireRATE + fireRATEUpgradeLevel / 8),0.5f,25); }
        set { calculateFireRATE += value; } // add mathf clamp later if needed
    }

    public static float CalculateFireRANGE
    {
        get { return Mathf.Clamp(calculateFireRANGE,0.5f,3)+fireRANGEUpgradeLevel/20; }
        set { calculateFireRANGE += value; } // add mathf clamp later if needed
    }

    public static float CalculateDollars
    {
        get { return totalDollars; }
        set 
        {
            if (value < 0)
            {
            totalDollars += value; 
            }
            else if (value >= 0)
            {
            totalDollars += (value + (value*incomeUpgradeLevel/10));
            }

        }
    }

    public static void CalculateWeaponExp(float exp)
    {
        if (exp > 0)
        {
            float recievedexp = exp * (1 + ((weaponUpgradeLevel-1) * 0.1f));

                while (recievedexp+weaponExp >= 100)
                {
                    recievedexp -= 100;
                    weaponLevel++;
                CheckWeaponEvent.Raise();
                Debug.Log("weapon level increased" + weaponLevel);

                }
                weaponExp += recievedexp;
            Debug.Log(recievedexp + " exp gained new exp is: " + weaponExp);


        }

        if (exp < 0)
        {
            weaponExp += exp; // actually its minus
            if (weaponExp <0 && weaponLevel !=0)
            {
                weaponLevel--;
                weaponExp += 100;
                CheckWeaponEvent.Raise();
                Debug.Log("you lost weapon level, new level is: " + weaponLevel + "and exp is: " + weaponExp);
            }
            else if (weaponExp < 0 && weaponLevel==0)
            {
                weaponExp = 0;
                Debug.Log("You lost all your weapon level and weapon exp, weapon level is: " + weaponLevel + " Exp is: " + weaponExp);

            }

        }

    }


    public static float CalculateDamage()
    {
       return 1 + (weaponLevel / 5);
    }





    private void Awake()
    {
        
        FirstImplementations();
        GetDataFromDisk();
        ResetLevelData(); // it must work before play, not for only reset, order is important, is must work after GetDataFromDisk


        try
        {
        CheckWeaponEvent = Resources.Load<VoidEvent>("CheckWeaponEvent");
        }
        catch (System.Exception)
        {
            Debug.LogError("There must be CheckWeaponEvent on Resources Folder");
            throw;
        }

    }


    private void GetDataFromDisk()
    {
        fireRATEUpgradeLevel = PlayerPrefs.GetInt("fireRATEUpgradeLevel");
        weaponUpgradeLevel = PlayerPrefs.GetInt("weaponUpgradeLevel");
        fireRANGEUpgradeLevel = PlayerPrefs.GetInt("fireRANGEUpgradeLevel");
        totalDollars = PlayerPrefs.GetFloat("totalDollars");
        incomeUpgradeLevel = PlayerPrefs.GetInt("incomeUpgradeLevel");
        // level data is stored on LevelManager

    }

    private void FirstImplementations()
    {
        if (!PlayerPrefs.HasKey("fireRATEUpgradeLevel"))
        {
            PlayerPrefs.SetInt("fireRATEUpgradeLevel", 1);
        }
        if (!PlayerPrefs.HasKey("weaponUpgradeLevel"))
        {
            PlayerPrefs.SetInt("weaponUpgradeLevel", 1);
        }
        if (!PlayerPrefs.HasKey("fireRANGEUpgradeLevel"))
        {
            PlayerPrefs.SetInt("fireRANGEUpgradeLevel", 1);
        }
        if (!PlayerPrefs.HasKey("totalDollars"))
        {
            PlayerPrefs.SetFloat("totalDollars", 0);
        }
        if (!PlayerPrefs.HasKey("incomeUpgradeLevel"))
        {
            PlayerPrefs.SetInt("incomeUpgradeLevel", 1);
        }


        
    }

    public void UpgradeDataOnDisk()
    {
        PlayerPrefs.SetInt("fireRATEUpgradeLevel", fireRATEUpgradeLevel);
        PlayerPrefs.SetInt("weaponUpgradeLevel", weaponUpgradeLevel);
        PlayerPrefs.SetInt("fireRANGEUpgradeLevel", fireRANGEUpgradeLevel);
        PlayerPrefs.SetInt("incomeUpgradeLevel", incomeUpgradeLevel);
        PlayerPrefs.SetFloat("totalDollars", totalDollars);
    }



    public void ResetLevelData()
    {
        weaponExp = 0;
        weaponLevel = 0;
        calculateFireRATE = +baseFireRange;
        calculateFireRANGE = baseFireRange;//fireRANGEUpgradeLevel/10 +1;
        globalMoveSpeedMultiplier = 1;

        //its not for ingame usage, it will define things when scene starts, scene reset already resets things
    }



}
