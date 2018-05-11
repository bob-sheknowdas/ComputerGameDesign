using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour {

    public GameObject fireball;
    public float startingX;
    public float startingY;

    void Spawnfireball()
    {
        GameObject.Instantiate(fireball, new Vector3(startingX, startingY, 0), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Spawnfireball();
        //if(tag =="trigger")
            Destroy(this.gameObject);
    }
}
