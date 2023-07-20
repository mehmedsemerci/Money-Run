using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    int level;

    public int levelCount;

    GameObject levelPrefab;

    public static LevelManager instance;



  //  public ThemeData[] themes;




    void Awake()
    {
        instance = this;

        Application.targetFrameRate = 60;

        Resources.UnloadUnusedAssets();

        level = (PlayerPrefs.GetInt("Level") % levelCount) + 1;

        levelPrefab = Resources.Load("Levels/Level " + level) as GameObject;

        Instantiate(levelPrefab, new Vector3(0,-1,-5.5f), Quaternion.identity);

      //  RenderSettings.skybox = themes[level - 1].skyboxMaterial;

     //   RenderSettings.fogColor = themes[level - 1].fogColor;

    }

}
