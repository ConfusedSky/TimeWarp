using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whacker : MonoBehaviour {
    public Vector3 force;

    private float activeTill = 0f;

	void OnTriggerStay(Collider other)
    {
        if(Time.timeScale > .9f)
        {
            Debug.Log(other.gameObject);
            other.GetComponent<CharacterController>().Move(force*Time.deltaTime);
        }
    }

    public void Activate()
    {
        activeTill = Time.time + .5f;
    }
}
