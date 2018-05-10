using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour {

    void OnMouseDown()
    {
        SceneManager.LoadScene("Scene1");
    }
}
