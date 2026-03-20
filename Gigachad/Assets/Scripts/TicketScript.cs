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
    void OnCollisionEnter2D(Collision2D collision) // when the ticket collides
    {
        if (collision.gameObject.CompareTag("Player")) // collides with player
        {
            Destroy(Ticket); // ticket disappears
        }
    }
}
