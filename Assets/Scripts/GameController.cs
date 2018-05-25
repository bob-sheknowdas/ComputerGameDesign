using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject checkpoint = GameObject.Find(PlayerPrefs.GetString("checkpoint"));
        GameObject player = player = GameObject.FindGameObjectWithTag("Player");
        if(checkpoint != null)
        {
            player.transform.position = checkpoint.transform.position;
        }
    }
}
