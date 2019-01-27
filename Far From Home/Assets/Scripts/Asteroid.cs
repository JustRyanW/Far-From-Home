using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float Speed;

    public float Health = 2;
    public bool Hit;
    public float flashTime;
    Color origionalColor;
    public new MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        origionalColor = renderer.material.color;
        Hit = false;
    }

    void Update()
    {     
        Speed = Random.Range(50, 150);
        //Update object position
        transform.position += -Vector3.forward * Speed * Time.deltaTime;
        Destroy(gameObject, 20);//destroy the dome after 29s

        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    void FlashRed()
    {
        renderer.material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }
    void ResetColor()
    {
        renderer.material.color = origionalColor;
        Hit = false; 
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            if(Hit == false)
            {
                FlashRed();
                Hit = true;
            }        
            --Health;
        }
    }
}