using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1FinalStopper : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy1F")
        {
            other.GetComponent<Enemy1FinalController>().StopAttacking();
        }
    }
}
