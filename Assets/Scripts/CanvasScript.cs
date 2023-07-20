using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;
public class CanvasScript : MonoBehaviour
{
    public Button pause, resetLevel, upgradeFireRATE, upgradeWeapon, upgradeFireRANGE, incomeUpgradeLevel, OpenMenuButton, hapticButton; // actually no need to define buttons but maybe we want to setactive(false) them later for some reason instead of shared UI parent
    public TMP_Text upgradeFireRATEText, upgradeWeaponText, totaldollarsText, upgradeFireRANGEText, incomeUpgradeText, hapticStatusText;
    public GameObject startScreen, pauseScreen, runningScreen, winScreen, gameOverScreen, menuScreen;
    bool hapticFlag = false;

    GameState temporary;
    private void Awake()
    {
        UpdateCanvasScreens();
    }
    void Start()
    {
        TextUpdater();
    }

    public void OnlyDollarTextUpdater()
    {
        StartCoroutine(OnlyDollarTextUpdate());
    }
    IEnumerator OnlyDollarTextUpdate()
    {
        yield return new WaitForEndOfFrame();
        totaldollarsText.text = GameData.CalculateDollars.ToString();
    }

    public void HapticOnOff()
    {
        if (!hapticFlag)
        {
        MMVibrationManager.SetHapticsActive(false);
            hapticStatusText.text = "Haptic Off";
        }
        else
        {
        MMVibrationManager.SetHapticsActive(true);
            hapticStatusText.text = "Haptic On";
        }


    }



    public void TextUpdater()
    {
        Invoke("TextUpdate", 0.03f);
    }

    public void UpdateCanvasScreens()
    {
        switch (GameManager.gameState)
        {
            case GameState.start:
                startScreen.SetActive(true); pauseScreen.SetActive(false); runningScreen.SetActive(false); winScreen.SetActive(false); gameOverScreen.SetActive(false); menuScreen.SetActive(false);
                break;
            case GameState.pause:
                startScreen.SetActive(false); pauseScreen.SetActive(true); runningScreen.SetActive(false); winScreen.SetActive(false); gameOverScreen.SetActive(false); menuScreen.SetActive(false);
                break;
            case GameState.running:
                startScreen.SetActive(false); pauseScreen.SetActive(false); runningScreen.SetActive(true); winScreen.SetActive(false); gameOverScreen.SetActive(false); menuScreen.SetActive(false);
                break;
            case GameState.menu:
                startScreen.SetActive(false); pauseScreen.SetActive(false); runningScreen.SetActive(false); winScreen.SetActive(false); gameOverScreen.SetActive(false); menuScreen.SetActive(true);
                break;
            case GameState.gameover:
                startScreen.SetActive(false); pauseScreen.SetActive(false); runningScreen.SetActive(false); winScreen.SetActive(false); gameOverScreen.SetActive(true); menuScreen.SetActive(false);
                break;
            case GameState.win:
                startScreen.SetActive(false); pauseScreen.SetActive(false); runningScreen.SetActive(false); winScreen.SetActive(true); gameOverScreen.SetActive(false); menuScreen.SetActive(false);
                break;
            default:
                break;
        }
    }


    public void MenuOpenButton()
    {
        temporary = GameManager.gameState;
        OpenMenuButton.gameObject.SetActive(false);

        GameManager.ChangeGameState("menu");

    }

    public void MenuCloseButton()
    {
        Debug.Log(temporary.ToString());
        GameManager.ChangeGameState(temporary.ToString());
        OpenMenuButton.gameObject.SetActive(true);
    }

    public void MuteSfxSounds()
    {
        AudioManager.Instance.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
    }
    public void UnMuteSfxSounds()
    {
        AudioManager.Instance.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
    }



    private void TextUpdate()
    {
        if (GameManager.gameState == GameState.running)
        {
            totaldollarsText.text = GameData.CalculateDollars.ToString();
        }
        else if(GameManager.gameState != GameState.running)
        {
        totaldollarsText.text = GameData.CalculateDollars.ToString();
        Debug.Log("text güncellendi");
        upgradeWeaponText.text = "Lv" + GameData.weaponUpgradeLevel.ToString() + " Weapon " + GameData.weaponUpgradeLevel.ToString() + "00 dollar";
        upgradeFireRANGEText.text = "Lv" + GameData.fireRANGEUpgradeLevel.ToString() + " Range " + GameData.fireRANGEUpgradeLevel.ToString() + "00 dollar";
        upgradeFireRATEText.text = "Lv" + GameData.fireRATEUpgradeLevel.ToString() + " Rate " + GameData.fireRATEUpgradeLevel.ToString() + "00 dollar";
        incomeUpgradeText.text = "Lv" + GameData.incomeUpgradeLevel.ToString() + " Income " + GameData.incomeUpgradeLevel.ToString() + "00 dollar";
            
        }


    }


    

}
