﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D myRigid;
    public float speed;
    public LayerMask whatIsGround;
    public LayerMask whatIsHitable;
    private bool jump = false;
    private Animator animator;
    private GameObject bg1;
    private GameObject groundCheck;
    private GameObject swordCheck;
    private float oldPositionX;
    private int direction = 1;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        bg1 = GameObject.FindGameObjectWithTag("BackGround1");
        groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        swordCheck = GameObject.FindGameObjectWithTag("SwordHitCheck");
        oldPositionX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Physics2D.OverlapCircle(groundCheck.transform.position, 0.02f, whatIsGround))
            jump = false;

        float updown = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        else if (updown > 0 && jump == false)
        {
            Jump();
        }

        else
        {
            float leftright = Input.GetAxisRaw("Horizontal");
            Vector2 scale = transform.localScale;

            if (leftright < 0f)
            {
                direction = -1;
                Move();
            }
            else if (leftright > 0f)
            {
                direction = 1;
                Move();
            }
            else
            {
                StopMovement();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Killer")
        {
            SceneManager.LoadScene("loseScene");
        }
    }

    void Attack()
    {
        animator.SetTrigger("hitting");
        Vector2 position = new Vector2(swordCheck.transform.position.x + (0.4f * direction), swordCheck.transform.position.y);
        Collider2D enemy = Physics2D.OverlapCircle(position, 0.6f, whatIsHitable);
        if(enemy)
        {
            enemy.GetComponent<Hitable>().Hit();
        }
    }

    void Jump()
    {
        animator.SetBool("running", false);
        myRigid.velocity = new Vector2(myRigid.velocity.x, 12);
        jump = true;
    }

    void Move()
    {
        Vector2 scale = transform.localScale;
        myRigid.velocity = new Vector2(speed * direction, myRigid.velocity.y);

        if (jump == false)
            animator.SetBool("running", true);

        if (scale.x*direction < 0)
            transform.localScale = new Vector2(scale.x * -1, scale.y);

        if (this.transform.position.x < oldPositionX)
        {
            oldPositionX = this.transform.position.x;
            bg1.transform.position = new Vector2(bg1.transform.position.x + (speed / 800), bg1.transform.position.y);
        }
        else if (this.transform.position.x > oldPositionX)
        {
            oldPositionX = this.transform.position.x;
            bg1.transform.position = new Vector2(bg1.transform.position.x - (speed / 800), bg1.transform.position.y);
        }
    }

    void StopMovement()
    {
        animator.SetBool("running", false);
        myRigid.velocity = new Vector2(0, myRigid.velocity.y);
    }
}
