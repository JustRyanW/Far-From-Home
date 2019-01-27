using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {

    [Header("Ship Settings")]
    public float forwardSpeed = 20f;
    public float horizontaSpeed = 20f;
    public float horizontalAcceleration = 0.1f;
    float horizontalVelocity;
    public float playareaWidth = 14f;

    [Header("Laser Settings")]
    public GameObject laserPrefab;
    public float laserSpeed = 40f;
    public float weaponCooldownTime = 0.1f;
    float weapoonLastFireTime;

    [Header("Level Settings")]
    public Vector3 startPos = new Vector3 (0,0,-1000);
    public Vector3 endPos = new Vector3 (0,0,-100);
    float levelProgressPercent = 0;

    Transform player;
    Transform playerModel;
    Animator animator;

    void Start ()
    {
        player = transform.GetChild(0);
        playerModel = player.GetChild(0);
        animator = playerModel.GetComponent<Animator>();
    }
	
	void Update ()
    {
        Move();

        if (Input.GetButton("Fire") && Time.time - weapoonLastFireTime > weaponCooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab, playerModel.transform.position, transform.rotation);
            laser.GetComponent<Laser>().laserSpeed = laserSpeed;
            laser.transform.Rotate(Vector3.right * 90);
            Destroy(laser, 10f);
            weapoonLastFireTime = Time.time;
        }
	}

    void Move ()
    {    
        if (Input.GetAxisRaw("Horizontal") == 1 && player.position.x < playareaWidth)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, horizontaSpeed, horizontalAcceleration);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && player.position.x > -playareaWidth)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, -horizontaSpeed, horizontalAcceleration);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        } else
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, 0, horizontalAcceleration);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }

        player.transform.Translate(new Vector2(horizontalVelocity * Time.deltaTime, 0));

        levelProgressPercent += forwardSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(startPos, endPos, levelProgressPercent / 100);
    }
}
