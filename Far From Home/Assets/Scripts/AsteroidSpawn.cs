using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

    public float screenWidth = 7.5f;
    public GameObject Asteroid; // enemy object
    public float InvokeRate = 5.0f; // spawn rate
    public Transform Player; // used to keep updated player position
    public float Timer;// spawn timer
    private IEnumerator cocoroutine;

    void Start()
    {
        //Timer = Time.time + 3;
        InvokeRepeating("Spawn", 0f, InvokeRate);
    }

    void Update()
    {
        

    }

    void Spawn()
    {
        Instantiate(Asteroid, new Vector3(transform.position.x, 0, Random.Range(-screenWidth, screenWidth)), transform.rotation);
        //Timer = Time.time + 3;
    }
}
