using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState  {start, pause, running, menu, gameover,win}

public class GameManager : MonoBehaviour
{
    public static GameState gameState;
    //public VoidEvent resetProggressEvent;
    public static VoidEvent UpdateCanvasScreensEvent;
    public static VoidEvent UpdateDataOnDiskEvent;
    public static VoidEvent RotateCameraOnRunningEvent;


    private void Start()
    {
        try
        {
            UpdateDataOnDiskEvent = Resources.Load<VoidEvent>("UpdateDataOnDiskEvent");
        }
        catch (System.Exception)
        {
            Debug.Log("there should be UpdateDataOnDiskEvent in resources folder");
            throw;
        }
        try
        {
        UpdateCanvasScreensEvent = Resources.Load<VoidEvent>("UpdateCanvasScreensEvent");
        }
        catch (System.Exception)
        {
            Debug.Log("there should be UpdateCanvasEvent in resources folder");
            throw;
        }

        try
        {
        RotateCameraOnRunningEvent = Resources.Load<VoidEvent>("RotateCameraOnRunningEvent");
        }
        catch (System.Exception)
        {
            Debug.Log("there should be RotateCameraOnRunningEvent in resources folder");
            throw;
        }


        ChangeGameState("start"); // change later game should start with menu
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public static void ChangeGameState(string gameState)
    {
        switch (gameState)
        {
            case "start":
                GameManager.gameState = GameState.start;
                break;
            case "pause": 
                GameManager.gameState = GameState.pause;
                break;

            case "running":
                GameManager.gameState = GameState.running;
                RotateCameraOnRunningEvent.Raise();
                break;

            case "menu":
                GameManager.gameState = GameState.menu;
                break;

            case "gameover":
                GameManager.gameState = GameState.gameover;
                UpdateDataOnDiskEvent.Raise();
                break;
            case "win":
                GameManager.gameState = GameState.win;
                UpdateDataOnDiskEvent.Raise();
                break;
            default:
                break;
        }

        UpdateCanvasScreensEvent.Raise();
    }

}
