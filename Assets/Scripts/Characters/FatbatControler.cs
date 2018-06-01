using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatbatControler : Hitable
{
    public bool moveWithCamera;
    public AudioClip explodeSound;
    private AudioSource myAudioSource;
    private GameObject player;
    private GameObject mainCamera;
    private Animator animator;
    private float oldCamY;
    private float speed = 3.5f;
    private bool active = false;
    private bool exploding = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        myAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        oldCamY = mainCamera.transform.position.y;
    }

    void Update()
    {
        Vector3 position = transform.position;
        Vector3 playerPosition = player.transform.position;
        float playerDistance = Vector3.Distance(playerPosition, position);

        if (active)
        {
            float yDistance = playerPosition.y - position.y;

            if (yDistance < 0)
                yDistance *= -1;

            if (moveWithCamera)
                MoveWithCamera();

            if (yDistance <= 0.5 && playerDistance <= 1.5)
               animator.SetTrigger("explode");
            else if (!exploding)
                MoveTowardsPlayer(playerPosition);
        }
        else if (playerDistance <= 11)
            active = true;
    }

    void MoveWithCamera()
    {
        Vector3 position = transform.position;
        float currentCamY = mainCamera.transform.position.y;
        float newFatbatY = position.y + (currentCamY-oldCamY);
        transform.position = new Vector3(position.x, newFatbatY, position.z);
        oldCamY = currentCamY;
    }

    void MoveTowardsPlayer(Vector3 playerPosition)
    {
        Vector3 position = transform.position;
        Vector3 delta = playerPosition - position;
        Vector3 deltaNormalized = delta;
        deltaNormalized.Normalize();

        float moveSpeed = speed * Time.deltaTime;
        Vector3 moveVector = (deltaNormalized * moveSpeed);
        
        if (Mathf.Abs(delta.x) < Mathf.Abs(moveVector.x))
            moveVector.x = delta.x;
        if (Mathf.Abs(delta.y) < Mathf.Abs(moveVector.y))
            moveVector.y = delta.y;

        transform.position = transform.position + moveVector;
    }

    void DamagePlayer()
    {
        Vector2 position = this.transform.position;
        Vector2 playerPosition = player.transform.position;
        float playerDistance = Vector3.Distance(playerPosition, position);
        if (playerDistance <= 2)
            player.GetComponent<PlayerController>().Hit();
    }

    public override void Hit()
    {
        PlayerPrefs.SetInt("kills", 1 + PlayerPrefs.GetInt("kills"));
        base.Hit();
    }

    public void ResizeForExplosion()
    {
        transform.localScale = new Vector3(2, 2, 1);
    }

    public void PlayExplosionSound()
    {
        if(myAudioSource==null)
            myAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        myAudioSource.PlayOneShot(explodeSound);
        exploding = true;
    }
}
    

    
