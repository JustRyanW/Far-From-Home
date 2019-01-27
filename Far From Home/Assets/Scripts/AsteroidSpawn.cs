using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

    
    public GameObject[] Asteroid; // enemy object
    public float InvokeRate = 5; // spawn rate
    private float spawnX;
    private float spawnY;

    


    private void Awake()
    {
        InvokeRepeating("Spawn", 0f, InvokeRate);
    }

 


    void Spawn()
    {
        spawnX = Random.Range(-10, 10);
        spawnY = Random.Range(-1, 1);
        Vector2 SpawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(Asteroid[Random.Range(0, 4)], SpawnPosition, Quaternion.identity);
        //Instantiate(Asteroid[Random.Range(0, Asteroid.Length)], SpawnPosition, Quaternion.identity);    
    }
}
