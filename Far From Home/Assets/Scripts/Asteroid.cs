using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float Speed = 10f; //start Speed
    private Transform ThisTransform = null;


    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame

    void Update()
    {
        //Update object position
        ThisTransform.position += -ThisTransform.right * Speed * Time.deltaTime;
    }
}