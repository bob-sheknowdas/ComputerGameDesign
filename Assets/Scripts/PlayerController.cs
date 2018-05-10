using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D myRigid;
    public float speed;
    private bool jump = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && jump==false )
        {
            myRigid.velocity = new Vector2(myRigid.velocity.x, 9);
            jump = true;
            animator.SetBool("running", false);
        }
        Vector2 scale = transform.localScale;
        float movement = Input.GetAxis("Horizontal");
        if (movement < 0f)
        {
            if(scale.x > 0)
                transform.localScale = new Vector2(scale.x * -1, scale.y);
            if(jump == false)
                animator.SetBool("running", true);
            myRigid.velocity = new Vector2(-speed, myRigid.velocity.y);
        }
        else if (movement > 0f)
        {
            if (scale.x < 0)
                transform.localScale = new Vector2(scale.x * -1, scale.y);
            if (jump == false)
                animator.SetBool("running", true);
            myRigid.velocity = new Vector2(speed, myRigid.velocity.y);
        }
        else
        {
            animator.SetBool("running", false);
            myRigid.velocity = new Vector2(0, myRigid.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Killer")
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Plattform" && jump==true)
        {
            jump = false;
        }
    }
}
