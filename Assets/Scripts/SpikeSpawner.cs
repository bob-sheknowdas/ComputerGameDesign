using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour {
    public GameObject spike;
    public float startingX;
    public float startingY;
    void SpawnSpike()
    {
        GameObject.Instantiate(
        spike, new Vector3(startingX, startingY, 0), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SpawnSpike();
        //if(tag =="trigger")
        Destroy(this.gameObject);
    }
}
