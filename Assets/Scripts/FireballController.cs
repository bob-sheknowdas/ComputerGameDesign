using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {

    public int direction = -1;

	// Update is called once per frame
	void Update () {
        transform.Translate(0.45f*direction, 0, 0);
    }

    void switchDirection()
    {
        direction = direction * -1;
    }
}
