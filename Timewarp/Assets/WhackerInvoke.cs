using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackerInvoke : MonoBehaviour {

    public Whacker w;

	public void Activate()
    {
        w.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        w.gameObject.SetActive(false);
    }
}
