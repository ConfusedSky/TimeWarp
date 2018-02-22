using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBasedColider : MonoBehaviour {

    public GameObject go;
	
    void Start()
    {
        TimeManagement.instance.timeChanged += TimeUpdate;
    }

	// Update is called once per frame
	void TimeUpdate ()
    {
		if(Time.timeScale > .9f)
        {
            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }
	}
}
