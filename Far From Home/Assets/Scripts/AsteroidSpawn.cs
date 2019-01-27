using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

    public float spawnAreaWidth = 14f;
    public float spawnAreaHeight = 2f;
    public GameObject[] Asteroid; // enemy object
    public float InvokeRate = 1; // spawn rate
    private float spawnX;
    private float spawnY;

    


    private void Awake()
    {
        InvokeRepeating("Spawn", 0f, InvokeRate);
    }

 


    void Spawn()
    {
        spawnX = Random.Range(-spawnAreaWidth, spawnAreaWidth);
        spawnY = Random.Range(-spawnAreaHeight, spawnAreaHeight);
        Vector2 SpawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(Asteroid[Random.Range(0, Asteroid.Length)], SpawnPosition, Quaternion.identity);
    }
}
