using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikewallFaller : MonoBehaviour {

    public GameObject spikewall;
    public float gravity;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            spikewall.GetComponent<Rigidbody2D>().gravityScale = gravity;
            Destroy(gameObject);
        }


    }
}
