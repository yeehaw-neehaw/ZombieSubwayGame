/****************************************************************************
* File Name: EnemyManager.c
* Author: Michael Chiodo, Neha Sankarkumar
* DigiPen Email: michael.chiodo@digipen.edu, neha.sankarkumar@digipen.edu
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
    public float voiceCooldown = 10f;
    public float voiceTimer = 0;
    public static bool validLevel = true;

    void Start()
    {
        //Dictating enemy health scaling based on the level
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
        //Zombie voice noise timing, classical timer system
        if (voiceTimer < voiceCooldown && validLevel)
        {
            voiceTimer += Time.deltaTime;
        }
        else if (voiceTimer >= voiceCooldown && validLevel)
        {
            voiceTimer = 0;
            AudioManager.Instance.SFX[17].Play();
        }
        //If the target is not set for the enemy to follow, find the players transform again
        if (playerPos == null)
        {
            playerPos = GameObject.FindAnyObjectByType<PlayerMovement>().gameObject.transform;
        }
        //Moving the enemy towards the player
        myRb = gameObject.GetComponent<Rigidbody2D>();
        direction = playerPos.position - transform.position;
        myRb.linearVelocity = direction * followSpeed;
        anim.SetFloat("xVelocity",myRb.linearVelocity.x);
        //Animation purposes of flipping the sprite
        if (myRb.linearVelocity.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) // when enemy collides with bullet
        {
            enemyHealth -= playerDamage; // enemy health goes down
            AudioManager.Instance.SFX[19].Play();
            Debug.Log("Zombie hurt sound played");
            if (enemyHealth <= 0)
            {
                if ((UnityEngine.Random.Range(1,9) == 3) || (WalletManager.WalletPity >= 7)) // 1/8 chance OR if pity reached
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
                AudioManager.Instance.SFX[16].Play();
                if (Random.Range(1,9) == 4)
                {
                    AudioManager.Instance.SFX[8].Play();
                }
                Destroy(gameObject);
            }
        }
    }
}
