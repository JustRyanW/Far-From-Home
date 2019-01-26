using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {

    public GameObject laserPrefab;

    Transform player;
    Transform playerModel;
    Animator animator;

    public float forwardSpeed = 20f;
    public float horizontalSpeed = 40f;
    public float horizontalAcceleration = 0.1f;
    float horizontalVelocity;
    public float playareaWidth = 14f;

    public float bulletTime = 10f;
    public float weaponCooldownTime = 0.2f;
    float weaponLastFireTime;

    void Start ()
    {
        player = transform.GetChild(0);
        playerModel = player.GetChild(0);
        animator = playerModel.GetComponent<Animator>();
    }
	
	void Update ()
    {
        Move();

        if (Input.GetButton("Fire"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        if (Time.time - weaponLastFireTime > weaponCooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab, playerModel.position, playerModel.rotation);
            laser.transform.Rotate(Vector3.right * 90);
            Destroy(laser, bulletTime);
            weaponLastFireTime = Time.time;
        }
    }

    void Move () 
    {    
        if (Input.GetAxisRaw("Horizontal") == 1 && player.position.x < playareaWidth)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, horizontalSpeed, horizontalAcceleration);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && player.position.x > -playareaWidth)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, -horizontalSpeed, horizontalAcceleration);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        } else
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, 0, horizontalAcceleration);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }

        transform.Translate(new Vector3(horizontalVelocity * Time.deltaTime, 0, forwardSpeed * Time.deltaTime));
    }
}
