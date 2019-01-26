using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {

    Transform player;
    Transform playerModel;
    Animator animator;

    public float forwardSpeed = 20f;
    public float horizontalSpeed = 10f;

    public float turnAnimationValue;
    public float turnAnimationTime;

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
        transform.Translate(new Vector3(0, 0, forwardSpeed * Time.deltaTime));

        if (Input.GetAxisRaw("Horizontal") == 1 && player.position.x < 7.5)
        {
            player.Translate(new Vector2(horizontalSpeed * Time.deltaTime, 0));
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && player.position.x > -7.5)
        {
            player.Translate(new Vector2(-horizontalSpeed * Time.deltaTime, 0));
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        } else
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);

        }

    }
}
