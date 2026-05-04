/****************************************************************************
* File Name: CameraFollow.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Instructs the camera to follow a game object around
*
****************************************************************************/

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;

    // Update is called once per frame
    void Update()
    {
        //Changes the camera to be at the players position
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -5);
    }
}
