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
            myRigid.velocity = new Vector2(0,9);
            jump = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 scale = transform.localScale;
            if(scale.x > 0)
                transform.localScale = new Vector2(scale.x * -1, scale.y);
            if(jump == false)
            animator.SetBool("running", true);
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 scale = transform.localScale;
            if (scale.x < 0)
                transform.localScale = new Vector2(scale.x * -1, scale.y);
            if (jump == false)
                animator.SetBool("running", true);
            transform.Translate(speed, 0, 0);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("running", false);
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
