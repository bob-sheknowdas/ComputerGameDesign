using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D myRigid;
    public float speed;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigid.velocity = new Vector2(0,9);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed,0,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Killer")
        {
            this.gameObject.SetActive(false);
        }
    }
}
