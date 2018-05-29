using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1FinalController : MonoBehaviour {

    public Rigidbody2D myRigid;
    public GameObject fireball;
    private float currentTime = 0;
    private bool attacking = true;
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
        if (currentTime == 7)
        {
            currentTime = 0;
            if (attacking)
                Attack();
        }
        else
        {
            currentTime++;
        }
    }
    
    void Attack()
    {
        Vector2 position = this.transform.position;
        position.x = position.x + 1f;
        position.y = position.y - 1f;
        GameObject.Instantiate(fireball, new Vector2(position.x, position.y), Quaternion.AngleAxis(90, Vector3.forward));
    }

    void Move()
    {
        if (attacking)
            myRigid.velocity = new Vector2(3.8f, myRigid.velocity.y);
        else
            myRigid.velocity = new Vector2(myRigid.velocity.x, 3f);
    }

    public void StopAttacking()
    {
        attacking = false;
    }
}
