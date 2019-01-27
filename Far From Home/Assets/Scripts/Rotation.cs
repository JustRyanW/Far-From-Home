using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float maxDegreesPerSecond;


    float rotationX;
    float rotationY;

    void Start()
    {


        rotationX = Random.Range(-maxDegreesPerSecond, maxDegreesPerSecond);
        rotationY = Random.Range(-maxDegreesPerSecond, maxDegreesPerSecond);
    }

    void Update()
    {
        

        // Spin object around Y-Axis
        transform.Rotate(new Vector2(rotationX, rotationY) * Time.deltaTime);
    }
}