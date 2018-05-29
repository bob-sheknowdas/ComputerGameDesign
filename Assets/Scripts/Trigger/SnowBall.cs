using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {

    public GameObject snowball;
    public float speed;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1.73205080757f, speed * -1f);
            Destroy(this.gameObject);
           // while (snowball.transform.position.x >= 88)
                //Destroy(snowball);
        }

    }
}
