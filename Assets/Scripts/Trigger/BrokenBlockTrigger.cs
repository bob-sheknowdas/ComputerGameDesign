using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlockTrigger : MonoBehaviour {

    public GameObject block;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Destruction());
        }
    }

    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(1);
        block.GetComponent<Animator>().SetTrigger("brake");
        Destroy(block.GetComponent<BoxCollider2D>());
        Destroy(gameObject);
    }
}
