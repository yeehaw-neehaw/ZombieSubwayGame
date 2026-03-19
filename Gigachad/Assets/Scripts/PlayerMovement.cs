/****************************************************************************
* File Name: PlayerMovement.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Controlling player movement using directional
* input. Does not currently account for vector movement.
*
****************************************************************************/

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D MyRb;
    private Vector2 MovementInput;
    public float MoveSpeed = 5f;

    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        //Stops the object being moved from spinning all over the place
        MyRb.freezeRotation = true;
    }

    void Update()
    {
        MovementInput.x = Input.GetAxisRaw("Horizontal");
        MovementInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Conducts the actual movement of the gameObject
        MyRb.MovePosition(MyRb.position + MovementInput * MoveSpeed * Time.fixedDeltaTime);
    }
}
