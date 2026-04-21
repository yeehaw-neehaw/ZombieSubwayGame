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
    public float enemyHealth;
    private float playerDamage = PlayerStats.BulletDamage;
    public GameObject walletPrefab;
    public GameObject EnemyDeathAnim;
    Animator anim;
    SpriteRenderer sr;

    void Start()
    {
        if (PlayerStats.CurrentLevel == 1)
        {
            enemyHealth = 4f;
        }
        else if (PlayerStats.CurrentLevel == 2)
        {
            enemyHealth = 6f;
        }
        else if (PlayerStats.CurrentLevel == 3)
        {
            enemyHealth = 8f;
        }
        else if (PlayerStats.CurrentLevel == 4)
        {
            enemyHealth = 10f;
        }
        else if (PlayerStats.CurrentLevel == 5)
        {
            enemyHealth = 10f;
        }
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

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
        anim.SetFloat("xVelocity",myRb.linearVelocity.x);
        if (myRb.linearVelocity.x < 0)
        {
            sr.flipX = true;
            AudioManager.Instance.SFX[18].Play();
        }
        else
        {
            sr.flipX = false;
            AudioManager.Instance.SFX[18].Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) // when enemy collides with bullet
        {
            enemyHealth -= playerDamage; // enemy health goes down
            AudioManager.Instance.SFX[19].Play();
            if (enemyHealth <= 0)
            {
                if ((UnityEngine.Random.Range(1,9) == 4) || (WalletManager.WalletPity >= 10)) // 1/8 chance OR if pity reached
                {
                    Instantiate(walletPrefab, gameObject.transform.position, Quaternion.identity); // spawn wallet
                    WalletManager.WalletPity = 0; // reset pity
                    AudioManager.Instance.SFX[14].Play();
                }
                else // if no wallet spawned,
                {
                    WalletManager.WalletPity += 1; // increase pity
                }
                Instantiate(EnemyDeathAnim, gameObject.transform.position, Quaternion.identity);
                EnemySpawning.EnemiesAlive--;
                Destroy(gameObject);
                AudioManager.Instance.SFX[16].Play();
            }
        }
    }
}
