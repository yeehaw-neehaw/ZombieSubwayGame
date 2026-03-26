/****************************************************************************
* File Name: PlayerFire.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Shoots bullets from the players location
* towards the mouse.
*
****************************************************************************/

using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //Defining vars
    public GameObject bulletPrefab;
    private int maxbullets = 14;
    private int currentbullets = 14;
    public float bulletSpeed = .1f;
    public float cooldown = 0.3f;
    private float timer = 0;
    public float relodTime = 2.5f;
    private float reloadElapsedTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(currentbullets <= 0)
        {
            reloadElapsedTime += Time.deltaTime;
            if (reloadElapsedTime >= relodTime)
            {
                currentbullets = maxbullets;
                reloadElapsedTime = 0;
            }
        }
        else if (timer < cooldown)
        {
            timer += Time.deltaTime;
        }
        else if (Input.GetMouseButton(0))
        {
            //calculate direction and fire
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Fire((mousePos - new Vector3(transform.position.x, transform.position.y, 0)).normalized);
            // AudioManager.PlaySound("gunShoot");
            timer = 0;
            currentbullets--;
        }
    }

    void Fire(Vector3 direction)
    {
        //create a clone of the prefab and set values
        Vector3 spawnPos = transform.position + direction;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.LookRotation(Vector3.forward, direction));
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
    }
}
