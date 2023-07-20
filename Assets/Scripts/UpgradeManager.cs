using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public VoidEvent upgradeUpdatesEvent;
    

    public void UpgradeFireRATE()
    {
        if (GameData.fireRATEUpgradeLevel *100 <= GameData.CalculateDollars)
        {
            GameData.CalculateDollars = -GameData.fireRATEUpgradeLevel * 100;
            GameData.fireRATEUpgradeLevel++;
            upgradeUpdatesEvent.Raise();
        }

    }

    public void UpgradeFireRANGE()
    {
        if (GameData.fireRANGEUpgradeLevel * 100 <= GameData.CalculateDollars)
        {
            GameData.CalculateDollars = -GameData.fireRANGEUpgradeLevel * 100;
            GameData.fireRANGEUpgradeLevel++;
            upgradeUpdatesEvent.Raise();
        }
    }
    public void UpgradeWapon()
    {
        if (GameData.weaponUpgradeLevel * 100 <= GameData.CalculateDollars)
        {
            GameData.CalculateDollars = -GameData.weaponUpgradeLevel * 100;
            GameData.weaponUpgradeLevel++;
            upgradeUpdatesEvent.Raise();
        }
    }

    public void UpgradeIncome()
    {
        if (GameData.incomeUpgradeLevel * 100 <= GameData.CalculateDollars)
        {
            GameData.CalculateDollars = -GameData.incomeUpgradeLevel * 100;
            GameData.incomeUpgradeLevel++;
            upgradeUpdatesEvent.Raise();
        }
    }




}
