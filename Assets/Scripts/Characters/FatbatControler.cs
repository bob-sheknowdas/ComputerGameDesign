using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatbatControler : Hitable
{
    public Rigidbody2D myRigid;
    public float speed;
    public bool moveWithCamera;
    private GameObject player;
    private GameObject mainCamera;
    private int direction = -1;
    private Animator animator;
    private float oldY;
    private bool active = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        animator = GetComponent<Animator>();
        oldY = mainCamera.transform.position.y;
    }

    void Update()
    {
        Vector3 position = this.transform.position;
        Vector3 playerPosition = player.transform.position;
        float playerDistance = Vector3.Distance(playerPosition, position);

        if (active)
        {
            float yDistance = playerPosition.y - position.y;

            if (yDistance < 0)
                yDistance *= -1;

            if (moveWithCamera)
                MoveWithCamera(position);

            if (yDistance <= 1 && playerDistance <= 2)
            {
                myRigid.velocity = new Vector2(0, 0);
                animator.SetTrigger("explode");
            }
            else
            {
                MoveTowardsPlayer(position, playerPosition);
            }
        }
        else if (playerDistance <= 11)
            active = true;
    }

    void MoveWithCamera(Vector3 position)
    {
        float currentY = mainCamera.transform.position.y;
        float newFatbatY = position.y + (currentY-oldY);
        transform.position = new Vector3(position.x, newFatbatY, position.z);
        oldY = currentY;
    }

    void MoveTowardsPlayer(Vector2 position, Vector2 playerPosition)
    {
        float x = playerPosition.x - position.x;
        float y = playerPosition.y - position.y;
        myRigid.velocity = new Vector2(x * 1f, y * 1f);
    }

    void Explode()
    {
        Object.Destroy(this.gameObject);
    }

    void DamagePlayer()
    {
        Vector2 position = this.transform.position;
        Vector2 playerPosition = player.transform.position;
        float playerDistance = Vector3.Distance(playerPosition, position);
        if (playerDistance <= 4)
            player.GetComponent<PlayerController>().Hit();
    }

    public override void Destroy()
    {
        PlayerPrefs.SetInt("kills", 1 + PlayerPrefs.GetInt("kills"));
        base.Destroy();
    }
}
    

    
