using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = 20f;
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float bulletspeed = 10f;

    private Rigidbody rb;
    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Player movement
        //  press WASD 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Jumping
        // press spacebar to jump
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            // Give the sphere a rapid upward velocity
            rb.velocity = new Vector3(0f, jumpForce, 0f);
            isJumping = true;
        }

        //If the sphere is moving upwards and has a negative velocity (i.e. falling), mark it as no longer jumping
        if (isJumping && rb.velocity.y < 0)
        {
            isJumping = false;
        }

        // Gravity
        rb.AddForce(Vector3.down * gravity * Time.deltaTime);


        //Player shooting 
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletspeed;
        Destroy(bullet, 5f);    //destroy the bullet after 5 sec 
    }
}