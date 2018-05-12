using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour {
	
	public virtual void Hit ()
    {
        GetComponent<Animator>().SetTrigger("hit");
    }
}
