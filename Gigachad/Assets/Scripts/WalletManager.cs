using System.Net.Sockets;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    public static int WalletPity = 0; // a wallet WILL spawn when this hits 10
                                      // (10 enemies have not dropped wallets)

    void OnCollisionEnter2D(Collision2D collision) // when the ticket collides
    {
        if (collision.gameObject.CompareTag("Player")) // collides with player
        {
            Destroy(gameObject); // ticket disappears
            PlayerStats.PlayerCash += UnityEngine.Random.Range(1, 6); // cash 1-5
        }
    }
}
