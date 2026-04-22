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
    private float MoveSpeed = PlayerStats.PlayerMovementSpeed;
    private Animator anim;
    private SpriteRenderer sr;
    private bool updown = false; 

    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //Stops the object being moved from spinning all over the place
        MyRb.freezeRotation = true;
    }

    void Update()
    {
        if (!PlayerFire.pauseOn)
        {
            MovementInput.x = Input.GetAxisRaw("Horizontal");
            MovementInput.y = Input.GetAxisRaw("Vertical");

            anim.SetFloat("xVelocity", MovementInput.x);
            anim.SetBool("updown", updown);
            anim.SetFloat("yVelocity", MovementInput.y);
            if (MovementInput.x < 0 && !updown)
            {
                sr.flipX = true;
            }
            else if (MovementInput.x > 0)
            {
            }
            else
            {
                sr.flipX = false;
            }
            if (MovementInput.y < 0 || MovementInput.y > 0)
            {
                updown = true;

            }
            else
            {
                updown = false;
            }
        }
    }

    void FixedUpdate()
    {
        //Conducts the actual movement of the gameObject
        MyRb.MovePosition(MyRb.position + MovementInput.normalized * MoveSpeed * Time.fixedDeltaTime);
    }

    void WalkingSound()
    {
        AudioManager.Instance.SFX[7].Play();
    }
}
