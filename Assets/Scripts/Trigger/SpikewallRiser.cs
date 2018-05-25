using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikewallRiser : MonoBehaviour {

    public GameObject spikewall;
    public float speed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            spikewall.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }


    }
}
