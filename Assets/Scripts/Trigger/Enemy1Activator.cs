using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Activator : MonoBehaviour
{

    public GameObject enemy1;
    public Text textfield;
    public Image image;
    public string text;
    private GameObject panel;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("SpeechPanel");
        text = text.Replace('$', '\n');
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ActivateEnemy());
        }
    }
    public IEnumerator ActivateEnemy()
    {
        player.GetComponent<PlayerController>().SetActive(false);
        panel.GetComponent<Image>().enabled = true;
        textfield.text = text;
        image.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(3.5f);
        panel.GetComponent<Image>().enabled = false;
        textfield.text = "";
        image.GetComponent<Image>().enabled = false;

        player.GetComponent<PlayerController>().SetActive(true);
        enemy1.GetComponent<Enemy1Controller>().Activate();
        Destroy(this.gameObject);
    }

}
