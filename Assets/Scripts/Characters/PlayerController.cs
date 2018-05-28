using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Destroyable {
    
    public AudioClip swordSound;
    public Rigidbody2D myRigid;
    public LayerMask whatIsGround;
    public LayerMask whatIsHitable;
    public LayerMask whatIsIce;
    public float speed;
    public string sceneToRespawn;
    public bool hasSword;
    private AudioSource myAudioSource;
    private Animator animator;
    private GameObject groundCheck;
    private GameObject swordCheck;
    private bool alive = true;
    private bool grounded = true;
    private bool iced = false;
    private bool iceJump = false;
    private int direction = 1;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        swordCheck = GameObject.FindGameObjectWithTag("SwordHitCheck");
        myAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            CheckGroundedAndIced();

            animator.SetBool("grounded", grounded);
            animator.SetFloat("vSpeed", myRigid.velocity.y);

            if (!grounded)
                LimitFallSpeed();
            else
                iceJump = false;

            if (Input.GetKeyDown(KeyCode.Space) && hasSword)
                Attack();

            else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded == true)
                Jump();

            else if (!iced || myRigid.velocity.x * direction <= speed / 2)
            {
                float leftright = Input.GetAxisRaw("Horizontal");

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
                else if(!iceJump)
                {
                    StopMovement();
                }
            }
            else
            {
                animator.SetBool("running", false);
            }
        }
    }

    public void Hit()
    {
        alive = false;
        myRigid.velocity = new Vector2(0, 0);
        animator.SetTrigger("hit");
    }
    
    void LimitFallSpeed()
    {
        if (myRigid.velocity.magnitude > 20)
        {
            myRigid.velocity = Vector3.ClampMagnitude(myRigid.velocity, 15);
        }
    }

    void CheckGroundedAndIced()
    {
        if(groundCheck==null)
            groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        Vector3 position1 = groundCheck.transform.position;
        Vector3 position2 = new Vector3(position1.x + (direction * 0.43f), position1.y + 0.02f, position1.z);
        grounded = Physics2D.OverlapArea(position1, position2, whatIsGround);
        iced = Physics2D.OverlapArea(position1, position2, whatIsIce);
    }

    public override void Destroy()
    {
        PlayerPrefs.SetInt("deaths", 1+ PlayerPrefs.GetInt("deaths"));
        SceneManager.LoadScene(sceneToRespawn, LoadSceneMode.Single);
    }

    void Attack()
    {

        if (swordCheck == null)
            swordCheck = GameObject.FindGameObjectWithTag("SwordHitCheck");
        myAudioSource.PlayOneShot(swordSound);
        animator.SetTrigger("attacking");
        Vector2 position = new Vector2(swordCheck.transform.position.x + (0.4f * direction), swordCheck.transform.position.y);
        Collider2D enemy = Physics2D.OverlapCircle(position, 0.6f, whatIsHitable);
        if(enemy)
        {
            enemy.GetComponent<Hitable>().Hit();
        }
    }

    void Jump()
    {
        iceJump = iced;
        animator.SetBool("running", false);
        myRigid.velocity = new Vector2(myRigid.velocity.x, 12);
    }

    void Move()
    {
        Vector2 scale = transform.localScale;
        myRigid.velocity = new Vector2(speed * direction, myRigid.velocity.y);

        if (grounded == true)
            animator.SetBool("running", true);

        if (scale.x*direction < 0)
            transform.localScale = new Vector2(scale.x * -1, scale.y);
    }

    void StopMovement()
    {
        animator.SetBool("running", false);
        myRigid.velocity = new Vector2(0, myRigid.velocity.y);
    }

    public int GetDirection()
    {
        return direction;
    }

    public void SetActive(bool trueFalse)
    {
        animator.SetBool("running", false);
        alive = trueFalse;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Killer" || other.gameObject.tag == "Enemy1F")
        {
            Hit();
        }
    }
}
