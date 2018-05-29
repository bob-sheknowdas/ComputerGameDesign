using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    private Text level5Text;
    private Text level4Text;
    private Text level3Text;
    private Text level2Text;
    private Text level1Text;
    private Text startText;
    private int level = 5;

    // Use this for initialization
    void Start ()
    {
        level5Text = GameObject.Find("Level5Text").GetComponent<Text>();
        level4Text = GameObject.Find("Level4Text").GetComponent<Text>();
        level3Text = GameObject.Find("Level3Text").GetComponent<Text>();
        level2Text = GameObject.Find("Level2Text").GetComponent<Text>();
        level1Text = GameObject.Find("Level1Text").GetComponent<Text>();
        startText = GameObject.FindGameObjectWithTag("StartText").GetComponent<Text>();
        StartCoroutine(BlinkText());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        { 
            PlayerPrefs.SetInt("deaths", 0);
            PlayerPrefs.SetInt("kills", 0);
            PlayerPrefs.SetString("checkpoint", "");
            switch (level)
            {
                case 5: SceneManager.LoadScene("Scene1", LoadSceneMode.Single); break;
                case 4: SceneManager.LoadScene("Scene2", LoadSceneMode.Single); break;
                case 3: SceneManager.LoadScene("Scene3", LoadSceneMode.Single); break;
                case 2: SceneManager.LoadScene("Scene4", LoadSceneMode.Single); break;
                default: SceneManager.LoadScene("Scene5", LoadSceneMode.Single); break;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            level++;
            if (level > 5)
                level = 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            level--;
            if (level < 1)
                level = 5;
        }
        level5Text.color = Color.red;
        level4Text.color = Color.red;
        level3Text.color = Color.red;
        level2Text.color = Color.red;
        level1Text.color = Color.red;
        switch (level){
            case 5: level5Text.color = Color.green; break;
            case 4: level4Text.color = Color.green; break;
            case 3: level3Text.color = Color.green; break;
            case 2: level2Text.color = Color.green; break;
            default: level1Text.color = Color.green; break;
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
