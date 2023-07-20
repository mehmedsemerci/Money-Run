using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HazardType {knockback, slowdown,gameover/* ,collect */}

public class HazardScript : MonoBehaviour
{
   
    public HazardType hazardtype;
    public VoidEvent KnockBackEvent;
    
    // Start is called before the first frame update


    public void DoHazardAction()
    {
        switch (hazardtype)
        {
            case HazardType.knockback:
                GameData.CalculateWeaponExp(-10);
                KnockBackEvent.Raise(); // exp azalt
                break;
            case HazardType.slowdown:
                GameData.globalMoveSpeedMultiplier = 0.5f;
                break;
            case HazardType.gameover:
                GameManager.ChangeGameState("gameover");
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                break;
            //case HazardType.collect:
            //    gameObject.GetComponent<ObjectHealthScript>().DoCollectiblesJourney();
            //    break;
            default:
                break;
        }
    }


    

    public void DoHazardExit()
    {
        switch (hazardtype)
        {
            case HazardType.knockback:
                break;
            case HazardType.slowdown:
                GameData.globalMoveSpeedMultiplier = 1;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hazard i�i trigger tetiklendi");
    }

    // Update is called once per frame

}
