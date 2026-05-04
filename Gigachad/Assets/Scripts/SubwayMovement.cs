/****************************************************************************
* File Name: SubwayMovement.cs
* Author: Neha Sankarkumar
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Game Projects
*
* Description: Controls the movement of the (invisible) gameobject on the 
* subway which the camera follows.
*
****************************************************************************/

using UnityEngine;

public class SubwayMovement : MonoBehaviour
{
    private Rigidbody2D MyRb;
    private Vector2 MovementInput;
    public float MoveSpeed = 3f;

    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        //Stops the object being moved from spinning all over the place
        MyRb.freezeRotation = true;
    }

    void Update()
    {
        MovementInput.x = Input.GetAxisRaw("Horizontal");
        MovementInput.y = 0;
    }

    void FixedUpdate()
    {
        //Conducts the actual movement of the gameObject
        MyRb.MovePosition(MyRb.position + MovementInput * MoveSpeed * Time.fixedDeltaTime);
    }
}
