using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float degreesPerSecond;
    public float speed;

    void Update()
    {
        degreesPerSecond = Random.Range(-180, 180);
        speed = Random.Range(5, 15);
        // Spin object around Y-Axis
        transform.Rotate(new Vector2(Time.deltaTime * degreesPerSecond, speed));
    }
}