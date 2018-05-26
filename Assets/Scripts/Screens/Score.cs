using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {


    private Text levelText;
    private Text levelNumberText;
    private Text killText;
    private Text killNumberText;
    private Text deathText;
    private Text deathNumberText;
    private Text startText;
    private int level = 6;
    private float currentTime = 0;
    private bool blinking = false;

    // Use this for initialization
    void Start () {
        level = PlayerPrefs.GetInt("level");
        int kills = PlayerPrefs.GetInt("kills");
        int deaths = PlayerPrefs.GetInt("deaths");

        levelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
        levelNumberText = GameObject.FindGameObjectWithTag("LevelNumberText").GetComponent<Text>();
        levelNumberText.text = level.ToString();
        killText = GameObject.FindGameObjectWithTag("KillText").GetComponent<Text>();
        killNumberText = GameObject.FindGameObjectWithTag("KillNumberText").GetComponent<Text>();
        killNumberText.text = kills.ToString();
        deathText = GameObject.FindGameObjectWithTag("DeathText").GetComponent<Text>();
        deathNumberText = GameObject.FindGameObjectWithTag("DeathNumberText").GetComponent<Text>();
        deathNumberText.text = deaths.ToString();
        startText = GameObject.FindGameObjectWithTag("StartText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    { 
        if (blinking)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayerPrefs.SetInt("deaths", 0);
                PlayerPrefs.SetInt("kills", 0);
                PlayerPrefs.SetString("checkpoint", "");
                if (7-level < 5)
                    SceneManager.LoadScene("Scene"+(7-level), LoadSceneMode.Single);
                else
                    SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
            }
        }
        else if (currentTime >= 4)
        {
            blinking = true;
            StartCoroutine(BlinkText());
        }
        else if (currentTime >= 3)
        {
            killText.enabled = true;
            killNumberText.enabled = true;
            deathText.enabled = true;
            deathNumberText.enabled = true;
            currentTime += Time.deltaTime;
        }
        else if(currentTime>= 2)
        {
            levelText.enabled = true;
            levelNumberText.enabled = true;
            currentTime += Time.deltaTime;
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
