using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float speed;
    // Use this for initialization  
    public GameObject spike;
    // public float spawnTime;
    public float startingX;
    public float startingY;
    // public float minY;
    //public float maxY;


    void Update()
    {
        //   if (Input.GetKey (KeyCode.Space)) {  
        //  
        //   }  
        //   else if(Input.GetKeyDown(KeyCode.Space)){  
        //  
        //   }  
        //   else if(Input.GetKeyUp(KeyCode.Space)){  
        //  
        //   }  
        //   if(Input.GetMouseButton(0)){  
        //  
        //   }  
        //   else if(Input.GetMouseButtonDown(1)){  
        //  
        //   }  
        //   else if(Input.GetMouseButtonUp(2)){  
        //  
        //   }  
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2 * speed, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
    }
}