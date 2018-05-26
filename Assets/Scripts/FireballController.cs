using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {

    public AudioClip fireballFlySound;
    public AudioClip fireballExplodeSound;
    private AudioSource myAudioSource;
    private Animator animator;
    private float time = 0;
    private Vector2 direction = new Vector2(-0.1f, 0);
    private bool active = true;

    // Use this for initialization
    void Start()
    {
        myAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        myAudioSource.PlayOneShot(fireballFlySound);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (active)
        {
            transform.Translate(direction);
            time += Time.deltaTime;
            if (time > 2)
                EndMovement();
        }
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = Norm(direction);

        Debug.Log("pos1 " + transform.position);
        Debug.Log("rot1 " + transform.rotation);
        Debug.Log(this.direction);
        transform.rotation = Quaternion.LookRotation(this.direction);
        transform.rotation = new Quaternion(0, 0, transform.rotation.z, 1);
        Debug.Log("rot2 " + transform.rotation);
        Debug.Log("pos2 " + transform.position);
    }

    public void EndMovement()
    {
        active = false;
        animator.SetTrigger("end");
        myAudioSource.PlayOneShot(fireballExplodeSound);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

    private Vector2 Norm(Vector2 direction)
    {
        Vector2 normedDirection = direction.normalized * 0.1f;
        return normedDirection;
    }
}
