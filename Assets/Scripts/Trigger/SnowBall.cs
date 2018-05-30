using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {

    public GameObject snowball;
    public AudioClip landslideSound;
    private float speed = 2;
    private bool active = false;
    private AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !active)
        {
            myAudioSource.PlayOneShot(landslideSound);
            active = true;
        }

    }

    void Update()
    {
        if (active)
        {
            if (snowball.transform.position.x > 92)
            {
                snowball.transform.Rotate(0, 0, 0.01f * snowball.transform.position.x);
                snowball.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1.73205080757f, speed * -1f);
            }
            else
            {
                snowball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}
