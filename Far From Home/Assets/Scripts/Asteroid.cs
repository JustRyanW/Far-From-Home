using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float Speed; 
    private Transform ThisTransform = null;

    void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

    // Update is called once per frame

    void Update()
    {
        Speed = Random.Range(50, 150);
        //Update object position
        ThisTransform.position += -ThisTransform.forward * Speed * Time.deltaTime;
        Destroy(gameObject, 20);//destroy the dome after 29s
    }
}