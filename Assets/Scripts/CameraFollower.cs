using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public float offsetX;
    public float offsetY;
    public float smoothTime;
    private Vector2 velocity;
    private GameObject player;

    // Use this for initialization
    void Start () {
        MoveCamera();
    }

    void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if(player==null)
            player = GameObject.FindGameObjectWithTag("Player");
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(posX+offsetX, posY+offsetY, transform.position.z);
    }
}
