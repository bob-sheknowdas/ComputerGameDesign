using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlockTrigger : MonoBehaviour {

    public GameObject block;
    public GameObject pixi;
    public GameObject pixi_prisoned;

    private float secondsToWait = 0.4f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Destruction());
        }
    }

    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(secondsToWait);
        block.GetComponent<Animator>().SetTrigger("brake");
        Destroy(block.GetComponent<BoxCollider2D>());
        if (pixi_prisoned != null)
        {
            Destroy(pixi_prisoned);
            pixi.SetActive(true);
        }
        Destroy(gameObject);
    }
}
