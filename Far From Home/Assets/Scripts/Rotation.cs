using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float degreesPerSecond;
    public float speed;
    public float Health = 2;
    public bool Hit;
    public float flashTime;
    Color origionalColor;
    public new MeshRenderer renderer;

    void Start()
    {
        origionalColor = renderer.material.color;
        Hit = false;
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
        if (collision.gameObject.tag == "Lasor")
        {
            Hit = true;
        }
    }
    void Update()
    {
        if (Hit)
        {
            FlashRed();
        }

        degreesPerSecond = Random.Range(-180, 180);
        speed = Random.Range(5, 15);
        // Spin object around Y-Axis
        transform.Rotate(new Vector2(Time.deltaTime * degreesPerSecond, speed));
    }
}