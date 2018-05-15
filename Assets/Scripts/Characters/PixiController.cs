using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixiController : MonoBehaviour {

    private Vector2 velocity;
    private GameObject player;
    private int moveSteps;
    private int direction = -1;
    private bool follows = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MovePixi();
    }

    void FixedUpdate()
    {

        MovePixi();
}

    void MovePixi()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, 0.05f);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, 0.05f);

        if (moveSteps > 28)
        {
            moveSteps = 0;
            direction *= -1;
        }
        float xOffset = 0.005f*moveSteps*direction;
        moveSteps++;
        
        transform.position = new Vector3(posX - 0.25f  + xOffset , posY + 0.25f, transform.position.z);
    }
}
