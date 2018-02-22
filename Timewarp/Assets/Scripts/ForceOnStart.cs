using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForceOnStart : MonoBehaviour {

    public Vector3 force;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
