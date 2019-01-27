using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [HideInInspector]
    public float laserSpeed = 5;

	void Update () {
        transform.Translate(new Vector3(0, laserSpeed * Time.deltaTime,0));
	}

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
    }

}
