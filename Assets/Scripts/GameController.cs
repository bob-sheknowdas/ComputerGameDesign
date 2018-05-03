using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private float secondsCount=0;
    public Transform fireball;

    // Update is called once per frame
    void Update () {
        secondsCount += Time.deltaTime;
        if(secondsCount>1.5)
        {
            Instantiate(fireball, new Vector3(7, Random.Range(-3, 4), 0), Quaternion.identity);
            secondsCount = 0;
        }
    }
}
