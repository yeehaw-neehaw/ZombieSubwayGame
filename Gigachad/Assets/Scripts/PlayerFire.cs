/****************************************************************************
* File Name: PlayerFire.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Shoots bullets from the players location
* towards the mouse. Gets the player transform as location 
* for instantiating then gets the mouse position and calculates
* the proper rotation from that.
*
****************************************************************************/

using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //Defining vars
    public GameObject bulletPrefab;
    //The transform from which bullets will be firing
    public Transform firePoint;
    public float bulletSpeed = .1f;
    private Camera mainCam;
    //Vectors for calculating fire direction
    private Vector3 mousePos;
    private Vector3 direction;
    private Vector3 rotation;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        //Finding the mouse position based on the camera
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //direction is where the bullet has to go, rotation is what point around the firing transform that the projectile should come from
        direction = mousePos - firePoint.position;
        rotation = transform.position - mousePos;
        if (Input.GetButtonDown("Fire1"))
        {
            //Calling a function to fire
            Fire();
        }
    }

    void Fire()
    {
        //Instantiates the bullet, gets its rb, and sets velocity
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(rotation.x, rotation.y, 0));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(direction.x, direction.y) * bulletSpeed;
    }
}
