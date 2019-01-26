using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour {

    Transform Player;

    public float forwardSpeed = 20f;
    public float horizontalSpeed = 10f;

	void Start ()
    {
        Player = transform.GetChild(0);
	}
	
	void Update ()
    {
        Move();
	}

    void Move ()
    {
        transform.Translate(new Vector3(0, 0, forwardSpeed * Time.deltaTime));

        if (Input.GetAxisRaw("Horizontal") == 1 && Player.position.x < 7.5)
        {
            Player.Translate(new Vector2(horizontalSpeed * Time.deltaTime, 0));
        }
        if (Input.GetAxisRaw("Horizontal") == -1 && Player.position.x > -7.5)
        {
            Player.Translate(new Vector2(-horizontalSpeed * Time.deltaTime, 0));
        }
    }
}
