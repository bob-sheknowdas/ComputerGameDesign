using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDropTrigger : MonoBehaviour
{
    public GameObject cloud;
    public GameObject blocker;
    public float f_speed;
      void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(blocker);
            cloud.GetComponent<Rigidbody2D>().velocity = Vector2.down * f_speed;
        }
        
    }
}
