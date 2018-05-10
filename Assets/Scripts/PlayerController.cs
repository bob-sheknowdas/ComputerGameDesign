﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    void Update ()
    {
        float updown = Input.GetAxisRaw("Vertical");
        float leftright = Input.GetAxisRaw("Horizontal");
        if (updown>0 && jump==false )
        {
            myRigid.velocity = new Vector2(myRigid.velocity.x, 10);
            jump = true;
            animator.SetBool("running", false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("hitting");
        }
        Vector2 scale = transform.localScale;
        if (leftright < 0f)
        {
            if(scale.x > 0)
                transform.localScale = new Vector2(scale.x * -1, scale.y);
            if(jump == false)
                animator.SetBool("running", true);
            myRigid.velocity = new Vector2(-speed, myRigid.velocity.y);
        }
        else if (leftright > 0f)
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
            SceneManager.LoadScene("loseScene");
            // this.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" && jump==true)
        {
            Vector3 contactPoint = other.contacts[0].point;
            Vector3 center = other.collider.bounds.center;
            if( HitFromAbove(other))
                jump = false;
        }
    }

    bool HitFromAbove(Collision2D other)
    {
        Vector3 contactPoint = other.contacts[0].point;
        Bounds bounds = other.collider.bounds;
        Vector3 center = bounds.center;
        Vector3 extends = bounds.extents;

        return contactPoint.y > center.y && contactPoint.x > center.x - extends.x && contactPoint.x < center.x + extends.x;
    }
}
