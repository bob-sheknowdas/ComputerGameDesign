using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private Animator animator;
    private bool wasActivated = false;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !wasActivated)
        {
            wasActivated = true;
            animator.SetTrigger("activate");
            PlayerPrefs.SetString("checkpoint", name);
        }
    }

}
