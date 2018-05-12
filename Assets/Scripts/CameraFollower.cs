using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    private Vector2 velocity;
    private GameObject player;
    public float smoothTime;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        MoveCamera();
    }

    void FixedUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTime);

        transform.position = new Vector3(posX+0.5f, posY+0.5f, transform.position.z);
    }
}
