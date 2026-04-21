/****************************************************************************
* File Name: TicketScript
* Author: Neha Sankarkumar
* DigiPen Email: neha.sankarkumar@digipen.edu
* Course: Video Game Programming (Game Projects)
*
* Description: This script manages individual tickets. Manages collection, 
* despawning after a timer (in EnemySpawning.cs), picking them up, etc
****************************************************************************/
using UnityEngine;

public class TicketScript : MonoBehaviour
{
    public GameObject Ticket;

    void OnCollisionEnter2D(Collision2D collision) // when the ticket collides
    {
        if (collision.gameObject.CompareTag("Player")) // collides with player
        {
            Destroy(Ticket); // ticket disappears
            TicketSpawner.TicketSpawned = false;
            PlayerStats.TicketsCollected += 1;
            AudioManager.Instance.SFX[11].Play();
        }
    }
    void Update()
    {
        if (EnemySpawning.NoMoreTickets)
        {
            Destroy(Ticket);
        }
    }
}
