using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour {

    public int level;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPrefs.SetInt("level", level);
        SceneManager.LoadScene("ScoreScene");
    }
}
