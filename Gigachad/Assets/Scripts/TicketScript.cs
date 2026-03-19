using UnityEngine;

public class TicketScript : MonoBehaviour
{
    public GameObject Ticket;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(Ticket);
        }
    }
}
