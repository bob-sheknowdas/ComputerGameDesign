using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearTrigger : MonoBehaviour {

    public GameObject block;
    public GameObject spikewall;
    public int startingX;
    public int startingY;


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "player")
        {
            GameObject.Destroy(block);
            Instantiate(spikewall, new Vector3(startingX, startingY, 0), Quaternion.identity);
        }
            

    }

}
