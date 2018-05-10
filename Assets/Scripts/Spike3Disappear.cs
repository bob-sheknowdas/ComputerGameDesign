using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike3Disappear : MonoBehaviour {

    public GameObject wall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == wall)
            GameObject.Destroy(this.gameObject);
        
    }

    }
