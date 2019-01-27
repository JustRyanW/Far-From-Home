using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Laser")
        {
            StartCoroutine(GetComponentInParent<Flight>().PlayerDeath());
        }
    }
}
