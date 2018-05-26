using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1Controller : Hitable
{

    public Rigidbody2D myRigid;
    public GameObject fireball;
    public float speed;
    private GameObject player;
    private Animator animator;
    private int direction = -1;
    private float hitTime = 1;
    private float currentTime;
    private bool wasActivated = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        currentTime = hitTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (wasActivated)
        {
            Vector2 position = this.transform.position;
            Vector2 playerPosition = player.transform.position;
            if (SeesPlayer(position, playerPosition))
            {
                myRigid.velocity = new Vector2(0, myRigid.velocity.y);
                animator.SetBool("running", false);
                if (currentTime >= hitTime)
                {
                    Attack(position, playerPosition);
                    currentTime = 0;
                }
                currentTime += Time.deltaTime;
            }
            else
            {
                myRigid.velocity = new Vector2(speed * direction, myRigid.velocity.y);
                animator.SetBool("running", true);
                if (SeesWall())
                {
                    direction = -direction;
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
            }
        }
    }

    public void Activate()
    {
        wasActivated = true;
    }

    void Attack(Vector2 position, Vector2 playerPosition)
    {
        animator.SetTrigger("attacking");
        float x = this.transform.position.x + (0.5f * direction);
        float y = this.transform.position.y - 0.5f;
        Vector2 fireDirection = playerPosition - position;
        float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        GameObject.Instantiate(fireball, new Vector2(x, y), Quaternion.AngleAxis(angle + 180, Vector3.forward));
    }

    bool SeesPlayer(Vector2 position, Vector2 playerPosition)
    {
        float playerDistance = Vector3.Distance(playerPosition, position);
        return playerDistance < 5 && isPlayerInLookingDirection(position, playerPosition) && !isPlayerHidden(position, playerPosition) ;
    }

    bool isPlayerInLookingDirection(Vector2 position, Vector2 playerPosition)
    {
        return (playerPosition.x >= position.x && direction > 0) || (playerPosition.x <= position.x && direction < 0);
    }

    bool isPlayerHidden(Vector2 position, Vector2 playerPosition)
    {
        return Physics2D.Linecast(position, playerPosition, 1 << LayerMask.NameToLayer("Wall"));
    }

    bool SeesWall()
    {
        Vector2 position = this.transform.position;
        Vector2 startPosition = new Vector2(position.x, position.y - 0.5f);
        Vector2 endPosition = new Vector2(position.x + (0.6f * direction), position.y - 0.5f);
        return Physics2D.Linecast(startPosition, endPosition, 1 << LayerMask.NameToLayer("Wall"));
    }

    public override void Hit()
    {
        myRigid.velocity = new Vector2(0, 0);
        wasActivated = false;
        base.Hit();
    }

    public override void Destroy()
    {
        PlayerPrefs.SetInt("kills", 1 + PlayerPrefs.GetInt("kills"));
        PlayerPrefs.SetInt("level", 5);
        base.Destroy();
        SceneManager.LoadScene("ScoreScene", LoadSceneMode.Single);
    }
}
