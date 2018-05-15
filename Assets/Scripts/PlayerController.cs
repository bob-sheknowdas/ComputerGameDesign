using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public AudioClip dieSound;
    public AudioClip swordSound;
    public AudioClip jumpSound;
    public Rigidbody2D myRigid;
    public LayerMask whatIsGround;
    public LayerMask whatIsHitable;
    public float speed;
    public string sceneToRespawn;
    private AudioSource myAudioSource;
    private Animator animator;
    private GameObject groundCheck;
    private GameObject swordCheck;
    private bool alive = true;
    private bool grounded = true;
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
            grounded = IsGrounded();
            animator.SetBool("grounded", grounded);
            animator.SetFloat("vSpeed", myRigid.velocity.y);
            float updown = Input.GetAxisRaw("Vertical");

            if (!grounded)
                LimitFallSpeed();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }

            else if (updown > 0 && grounded == true)
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Killer")
        {
            Hit();
            if (other.gameObject.layer == 11)
            {
                other.gameObject.GetComponent<FireballController>().EndMovement();
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

    bool IsGrounded()
    {
        Vector3 position1 = groundCheck.transform.position;
        Vector3 position2 = new Vector3(position1.x + 0.4f, position1.y + 0.02f, position1.z);
        return Physics2D.OverlapArea(position1, position2, whatIsGround);
    }

    void Die()
    {
        myAudioSource.PlayOneShot(dieSound);
        myAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        PlayerPrefs.SetInt("deaths", 1+ PlayerPrefs.GetInt("deaths"));
        SceneManager.LoadScene(sceneToRespawn);
    }

    void Attack()
    {
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
        myAudioSource.PlayOneShot(jumpSound);
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
}
