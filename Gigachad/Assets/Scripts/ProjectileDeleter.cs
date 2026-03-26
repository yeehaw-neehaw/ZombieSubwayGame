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
    public int ricochetPower = 1;
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
