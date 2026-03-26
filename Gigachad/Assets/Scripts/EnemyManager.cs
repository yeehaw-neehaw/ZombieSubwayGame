/****************************************************************************
* File Name: EnemyManager.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Instructs anything this script is attached to to follow after
* another transform.
*
****************************************************************************/

using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static Transform playerPos;
    private Vector3 direction;
    private Rigidbody2D myRb;
    public float followSpeed = 0.5f;
    public float enemyHealth = 4f;
    public float playerDamage = 2f;
    public GameObject walletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (playerPos == null)
        {
            playerPos = GameObject.FindAnyObjectByType<PlayerMovement>().gameObject.transform;
        }

        myRb = gameObject.GetComponent<Rigidbody2D>();
        direction = playerPos.position - transform.position;
        myRb.linearVelocity = direction * followSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) // when enemy collides with bullet
        {
            enemyHealth -= playerDamage; // enemy health goes down
            if (enemyHealth <= 0)
            {
                if ((UnityEngine.Random.Range(1,9) == 4) || (WalletManager.WalletPity >= 10)) // 1/8 chance OR if pity reached
                {
                    Instantiate(walletPrefab, gameObject.transform.position, Quaternion.identity); // spawn wallet
                    WalletManager.WalletPity = 0; // reset pity
                }
                else // if no wallet spawned,
                {
                    WalletManager.WalletPity += 1; // increase pity
                }
                
                Destroy(gameObject);
            }
        }
    }
}
