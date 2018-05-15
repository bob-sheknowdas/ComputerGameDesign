using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatbatControler : Hitable
{
    private GameObject player;
    public Rigidbody2D myRigid;
    //private bool wasActivated = true;
    private int direction = -1;
    public float speed;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector2 position = this.transform.position;
        Vector2 playerPosition = player.transform.position;
        float playerDistance = Vector3.Distance(playerPosition, position);

            float x = player.transform.position.x - transform.position.x;
            float y = player.transform.position.y - transform.position.y;
            myRigid.velocity = new Vector2(x * 0.5f, y * 0.5f);

            if ( playerDistance <= 2)
            {
                animator.SetTrigger("explode");
            }
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



}
    

    
