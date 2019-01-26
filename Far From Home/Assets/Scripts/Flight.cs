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
        playerModel = transform.GetChild(0);
        animator = playerModel.GetComponent<Animator>();
	}
	
	void Update ()
    {
        Move();

        float rotationZ = turnAnimationTime * 25;
        float rotationY = turnAnimationTime * -20;

        //player.rotation.y = Quaternion.e;
	}

    void Move ()
    {
        transform.Translate(new Vector3(0, 0, forwardSpeed * Time.deltaTime));

        if (Input.GetAxisRaw("Horizontal") == 1 && player.position.x < 7.5)
        {
            player.Translate(new Vector2(horizontalSpeed * Time.deltaTime, 0));
            turnAnimationValue = Mathf.Lerp(turnAnimationValue, 1, turnAnimationTime);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && player.position.x > -7.5)
        {
            player.Translate(new Vector2(-horizontalSpeed * Time.deltaTime, 0));
            turnAnimationValue = Mathf.Lerp(turnAnimationValue, -1, turnAnimationTime);
        } else
        {
            turnAnimationValue = Mathf.Lerp(turnAnimationValue, 0.5f, turnAnimationTime);
        }

    }
}
