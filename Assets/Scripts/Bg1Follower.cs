using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg1Follower : MonoBehaviour {

    private GameObject player;
    private Vector2 playerPosition;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 playerPositionNew = player.transform.position;
        float offsetX = playerPosition.x - playerPositionNew.x;
        
        transform.position = new Vector2(transform.position.x + (offsetX / 25), transform.position.y);

        playerPosition = playerPositionNew;

    }
}
