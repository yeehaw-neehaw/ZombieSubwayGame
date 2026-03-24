/****************************************************************************
* File Name: TicketScript
* Author: Neha Sankarkumar
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Video Game Programming (Game Projects)
*
* Description: This code switches scenes upon a button being clicked. 
****************************************************************************/
using UnityEngine;

public class TicketScript : MonoBehaviour
{
    public GameObject Ticket;
    private float TimerMax = 20f; // TIMERMAX seconds elapse before a ticket will spawn
    private float TimerCounter = 0f; // the actual timer

    void OnCollisionEnter2D(Collision2D collision) // when the ticket collides
    {
        if (collision.gameObject.CompareTag("Player")) // collides with player
        {
            Destroy(Ticket); // ticket disappears
        }
    }

    void Update()
    {
        if (EnemySpawning.levelCountdown >= EnemySpawning.levelTimer)
        {
            if (TimerCounter < TimerMax) // if the timer has not yet reached TIMERMAX seconds
            {
                TimerCounter += Time.deltaTime; // update timer
            }
            else
            {
                Destroy(Ticket);
            }
        }

    }
}
