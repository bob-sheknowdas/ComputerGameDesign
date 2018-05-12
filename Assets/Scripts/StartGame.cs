using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    Text startText;
    private float currentTime = 0;
    private float blinkTime = 2;
    private bool blinking = false;

    // Use this for initialization
    void Start()
    {
        startText = GameObject.FindGameObjectWithTag("StartText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        if (blinking)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Scene1");
            }
        }
        else if (currentTime >= blinkTime)
        {
            blinking = true;
            StartCoroutine(BlinkText());
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            startText.enabled = true;
            yield return new WaitForSeconds(1);
            startText.enabled = false;
            yield return new WaitForSeconds(1);
        }
    }
}
