using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public GameObject controlTexts;
    public GameObject controlImages;
    private Text startText;
    private float currentTime = 0;
    private float blinkTime = 2;
    private bool blinking = false;
    private bool enterPressedOnce = false;

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
                if (enterPressedOnce)
                {
                    PlayerPrefs.SetInt("deaths", 0);
                    PlayerPrefs.SetInt("kills", 0);
                    PlayerPrefs.SetString("checkpoint", "");
                    SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
                }
                else
                {
                    enterPressedOnce = true;
                    controlTexts.SetActive(true);
                    controlImages.SetActive(true);
                    startText.text = "Press Enter again!";
                }
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
        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
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
