using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearTrigger : MonoBehaviour {

    public GameObject block;
    public GameObject spikewall;
    public float startingX;
    public float startingY;


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Destroy(block);
            Instantiate(spikewall, new Vector3(startingX, startingY, 0), Quaternion.identity);
        }
            

    }

}
