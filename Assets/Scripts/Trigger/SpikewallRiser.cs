using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikewallRiser : MonoBehaviour {

    public GameObject spikewall;
    public float hight;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            spikewall.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3.2f;
        }


    }

    void Update()
    {
        if (spikewall.transform.position.y >= hight)
            spikewall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
