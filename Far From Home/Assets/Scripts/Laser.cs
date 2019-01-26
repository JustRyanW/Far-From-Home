using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float laserSpeed;

	void Update () {
        transform.Translate(new Vector3(0, laserSpeed * Time.deltaTime,0));
	}
}
