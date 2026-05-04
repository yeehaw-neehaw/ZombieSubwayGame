/****************************************************************************
* File Name: EnemyDeath.cs
* Author: Bishep Clous
* DigiPen Email: bishep.clous@digipen.edu
* Course: Game Projects
*
* Description: Destroys the new sprite created for enemy death animation
*
****************************************************************************/

using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.76f);
    }
}
