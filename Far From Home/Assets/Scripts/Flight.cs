using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {

    Transform player;
    Transform playerModel;
    Animator animator;

    public float forwardSpeed = 20f;
    public float horizontalAcceleration = 0.05f;
    float horizontalSpeed;
    public float playareaWidth = 7f;

	void Start ()
    {
        player = transform.GetChild(0);
        playerModel = player.GetChild(0);
        animator = playerModel.GetComponent<Animator>();
    }
	
	void Update ()
    {
        Move();
	}

    void Move ()
    {    
        if (Input.GetAxisRaw("Horizontal") == 1 && player.position.x < playareaWidth)
        {
            horizontalSpeed = Mathf.Lerp(horizontalSpeed, forwardSpeed, horizontalAcceleration);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && player.position.x > -playareaWidth)
        {
            horizontalSpeed = Mathf.Lerp(horizontalSpeed, -forwardSpeed, horizontalAcceleration);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        } else
        {
            horizontalSpeed = Mathf.Lerp(horizontalSpeed, 0, horizontalAcceleration);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }

        transform.Translate(new Vector3(horizontalSpeed * Time.deltaTime, 0, forwardSpeed * Time.deltaTime));
    }
}
