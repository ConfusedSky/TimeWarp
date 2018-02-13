using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    public GameObject prefab;
    public int frequency = 4;

    float timeSince = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > timeSince + (float)1/frequency)
        {
            timeSince = Time.time;
            Instantiate(prefab, transform.position, Quaternion.identity, gameObject.transform);
        }
	}
}
