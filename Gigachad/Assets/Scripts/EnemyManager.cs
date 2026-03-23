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

public class EnemyFollow : MonoBehaviour
{
    public Transform playerPos;
    public Transform selfPos;
    private Vector3 direction;
    private Rigidbody2D myRb;
    public float followSpeed = 0.5f;
    public float enemyHealth = 4f;
    public float playerDamage = 2f;

    // Update is called once per frame
    void Update()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        direction = playerPos.position - selfPos.position;
        myRb.linearVelocity = direction * followSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) // when enemy collides with bullet
        {
            enemyHealth -= playerDamage; // enemy health goes down
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
