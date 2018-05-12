using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : Hitable {

    public Sprite damagedSprite;
    private int hitcount = 0;

    public override void Hit()
    {
        Debug.Log("A");
        hitcount++;
        if (hitcount == 1)
        {
            GetComponent<Animator>().SetTrigger("damaged");
        }
        else if (hitcount >= 3)
        {
            base.Hit();
        }
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
