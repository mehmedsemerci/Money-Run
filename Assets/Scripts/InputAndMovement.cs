using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum GameControls {pc, mobile }
public class InputAndMovement : MonoBehaviour
{
    public float horizontalSpeed, verticalSpeed;
    private float xinput;
    public GameControls gameControls;
    bool knockedBack = false;

    #region knockbackdotweenparameters
    public Vector3 DT_endPosition;
    public float DT_jumpPower;
    public int DT_jumpCount;
    public float DT_duration;


    #endregion



    void Start()
    {
        if (gameControls==GameControls.pc){Invoke("GameStateChangeForPcDebugOnly", 0.2f);}

    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.gameState)
        {
            case GameState.start:
                TapToStartControl();
                break;
            case GameState.pause:
                SwipeToUnpauseControl();
                break;
            case GameState.running:
                Controls();
                ScreenClamp();
                break;
            case GameState.menu:
                break;
            case GameState.gameover:
                break;
            case GameState.win:
                break;
            default:
                break;
        }








    }
    public void GetKnockedBack()
    {
        if (!knockedBack)
        {
           // knockedBack = true;
       StartCoroutine(KnockBack());

        }

    }

    IEnumerator KnockBack()
    {
        

        Debug.Log("knocked back");

        transform.DOLocalJump(transform.position +DT_endPosition, DT_jumpPower, DT_jumpCount, DT_duration);

        yield return new WaitForSecondsRealtime(DT_duration);
       // knockedBack = false;

    }



    public void Controls()
    {
        switch (gameControls)
        {
            case GameControls.pc:
                InputControlPc();
                break;
            case GameControls.mobile:
                InputControlPhone();
                break;
            default:
                break;
        }
    }

    private void InputControlPc()
    {
        xinput = Input.GetAxis("Horizontal");
        gameObject.transform.Translate((new Vector3(xinput * horizontalSpeed * 10, 0, verticalSpeed* GameData.globalMoveSpeedMultiplier)) * Time.deltaTime);
    }
    private void GameStateChangeForPcDebugOnly()
    {
        GameManager.ChangeGameState("running");
    }





    private void InputControlPhone()
    {
        bool isMovingHorizontal = false;
        if (Input.touchCount > 0)
        {
            Debug.Log("tiklandi");
            Touch parmak = Input.GetTouch(0);

            if (parmak.deltaPosition.x > 1f)
            {
                gameObject.transform.Translate((new Vector3(parmak.deltaPosition.x * horizontalSpeed, 0, verticalSpeed * GameData.globalMoveSpeedMultiplier)) * Time.deltaTime);
                isMovingHorizontal = true;
            }
            else if (parmak.deltaPosition.x < -1f)
            {
                gameObject.transform.Translate((new Vector3(parmak.deltaPosition.x * horizontalSpeed, 0, verticalSpeed * GameData.globalMoveSpeedMultiplier)) * Time.deltaTime);
                isMovingHorizontal = true;
            }

        }



        if (!isMovingHorizontal)
        {
            gameObject.transform.Translate((new Vector3(0 , 0, verticalSpeed * GameData.globalMoveSpeedMultiplier)) * Time.deltaTime);
        }


    }


    private void SwipeToUnpauseControl()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            if (parmak.deltaPosition.x > 40f)
            {
                GameManager.ChangeGameState("running");
            }

        }
    }

    private void TapToStartControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                GameManager.ChangeGameState("pause");
            }
        }
    }



    private void ScreenClamp()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), transform.position.y, transform.position.z);
    }



}