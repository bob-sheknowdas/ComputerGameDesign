using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Activator : MonoBehaviour {

    public GameObject enemy1;

    void OnTriggerEnter2D(Collider2D other)
    {
        enemy1.GetComponent<Enemy1Controller>().Activate();

        Destroy(this.gameObject);
    }
}
