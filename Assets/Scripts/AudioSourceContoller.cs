using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSourceContoller : MonoBehaviour
{

    public static AudioSourceContoller Instance;
    private static string LevelName;

    void Awake()
    {
        this.InstantiateController();
    }

    private void InstantiateController()
    {
        if (Instance == null)
        {
            Instance = this;
            LevelName = SceneManager.GetActiveScene().name;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != LevelName)
        {
            Instance = null;
            Destroy(this.gameObject);
        }
    }
}
