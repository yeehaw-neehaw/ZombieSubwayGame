/****************************************************************************
* File Name: EnemyFollow.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Instructs anything this script is attached to to follow after
* another transform.
*
****************************************************************************/

using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform playerPos;
    public Transform selfPos;
    private Vector3 direction;
    private Rigidbody2D myRb;
    public float followSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        direction = playerPos.position - selfPos.position;
        myRb.linearVelocity = direction * followSpeed;
    }
}
