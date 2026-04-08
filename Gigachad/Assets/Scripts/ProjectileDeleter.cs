/****************************************************************************
* File Name: ProjectileDeleter.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Decrements the ricochet power of a bullet every time it hits certain things.
*
****************************************************************************/

using UnityEngine;

public class ProjectileDeleter : MonoBehaviour
{
    private int ricochetPower;
    private Rigidbody2D myRb;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        SubwayOffSubway.hasDeleted = false;
        ricochetPower = PlayerStats.RicochetLevel;
    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Mathf.Clamp(myRb.linearVelocity.x, -10, 10), Mathf.Clamp(myRb.linearVelocity.y, -10, 10));
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            if (ricochetPower <= 0)
            {
                Destroy(gameObject);
            }
            ricochetPower -= 1;
        }
    }
}
