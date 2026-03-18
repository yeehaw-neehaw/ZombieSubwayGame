/****************************************************************************
* File Name: PlayerMovement.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: A basic script for shooting bullets from the players location
* towards the mouse. Gets the player transform as location for instantiating
* then gets the mouse position and calculates the proper rotation from that.
*
****************************************************************************/

using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = .1f;
    private Camera mainCam;
    private Vector3 mousePos;
    private Vector3 direction;
    private Vector3 rotation;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - firePoint.position;
        rotation = transform.position - mousePos;
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(rotation.x, rotation.y, 0));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(direction.x, direction.y) * bulletSpeed;
    }
}
