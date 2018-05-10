using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    public Rigidbody2D myRigid;
    public float speed;
    public int jumpforce;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigid.velocity = new Vector2(0,jumpforce);
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
        if (other.gameObject.tag == "trigger")
            Destroy(other.gameObject);
        else if (other.gameObject.tag == "Killer")
            SceneManager.LoadScene("losescene");
        
       // {this.gameObject.SetActive(false);}
    }
}
