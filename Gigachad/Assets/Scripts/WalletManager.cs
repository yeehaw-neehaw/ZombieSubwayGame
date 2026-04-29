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
            AudioManager.Instance.SFX[0].Play();
            Destroy(gameObject); // ticket disappears
            PlayerStats.PlayerCash += UnityEngine.Random.Range(3, 6); // cash 3-5
        }
    }
}
