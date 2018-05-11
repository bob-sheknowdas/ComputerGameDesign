using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour {

    public Rigidbody2D myRigid;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	public void Hit ()
    {
        myRigid.velocity = new Vector2(0, myRigid.velocity.y);
        animator.SetTrigger("hit");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
