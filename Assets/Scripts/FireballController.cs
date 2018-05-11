using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {
    
    private float time = 0;
    private Vector2 direction = new Vector2(-0.1f, 0);

    // Update is called once per frame
    void Update () {
        transform.Translate(direction);
        time += Time.deltaTime;
        if (time > 1.5)
            Destroy(this.gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = Norm(direction);

        Debug.Log("pos1 " + transform.position);
        Debug.Log("rot1 " + transform.rotation);
        Debug.Log(this.direction);
        transform.rotation = Quaternion.LookRotation(this.direction);
        transform.rotation = new Quaternion(0, 0, transform.rotation.z, 1);
        Debug.Log("rot2 " + transform.rotation);
        Debug.Log("pos2 " + transform.position);
    }

    private Vector2 Norm(Vector2 direction)
    {
        Vector2 normedDirection = direction.normalized * 0.1f;
        return normedDirection;
    }
}
