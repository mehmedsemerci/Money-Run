using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update


    public void DoFinish()
    {
        GameManager.ChangeGameState("win");
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
  

    }

}
