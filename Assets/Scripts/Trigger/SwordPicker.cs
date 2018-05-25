using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPicker : MonoBehaviour
{

    public GameObject ninja;
    public GameObject ninjaWithSword;
    public GameObject block;
    private float secondsToWait = 0.2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(PickSword());
    }

    IEnumerator PickSword()
    {
        ninjaWithSword.SetActive(true);
        ninjaWithSword.transform.position = ninja.transform.position;
        ninja.SetActive(false);
        yield return new WaitForSeconds(secondsToWait);
        block.GetComponent<Animator>().SetTrigger("brake");
        Destroy(block.GetComponent<BoxCollider2D>());
        Destroy(gameObject);
    }

}
