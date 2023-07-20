using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float xOffset, yOffset, zOffset; // xLook, yLook, zLook;
    public float xFinalRotation;
    private void LateUpdate()
    {
        if (GameManager.gameState == GameState.running)
        {
        transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z) + new Vector3(xOffset, yOffset, zOffset);
       // transform.LookAt(new Vector3(0, player.transform.position.y, player.transform.position.z) + new Vector3(xLook, yLook, zLook));
        }

    }

    public void RotateCameraOnRunningStart()
    {

        transform.DORotate(new Vector3(xFinalRotation, 0, 0) , 1.25f);

    }



}
