using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextTrigger : MonoBehaviour
{

    public Text textfield;
    public Image image;
    public string text;
    public float secondsToShow;
    private GameObject panel;

    // Use this for initialization
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("SpeechPanel");
        text = text.Replace('$', '\n');
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ShowText());
        }
    }

    public IEnumerator ShowText()
    {
        panel.GetComponent<Image>().enabled = true;
        textfield.text = text;
        image.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(secondsToShow);
        panel.GetComponent<Image>().enabled = false;
        textfield.text = "";
        image.GetComponent<Image>().enabled = false;
        Destroy(gameObject);
    }
}
