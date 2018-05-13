using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : Destroyable {
	
	public virtual void Hit ()
    {
        GetComponent<Animator>().SetTrigger("hit");
    }
}
