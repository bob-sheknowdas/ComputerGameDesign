using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        GameObject checkpoint = GameObject.Find(PlayerPrefs.GetString("checkpoint"));
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy1Final = GameObject.FindGameObjectWithTag("Enemy1F");
        if (checkpoint != null)
        {
            player.transform.position = checkpoint.transform.position;
        }
        if (enemy1Final != null)
        {
            Vector3 enemyPosition = enemy1Final.transform.position;
            enemy1Final.transform.position = new Vector3(player.transform.position.x - 13.5f, enemyPosition.y, enemyPosition.z);
        }
    }
}
