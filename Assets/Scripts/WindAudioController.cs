using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindAudioController : MonoBehaviour
{

    void Awake()
    {
        StartCoroutine(PlayWindSound());
    }

    public IEnumerator PlayWindSound()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().Play();
    }
}
