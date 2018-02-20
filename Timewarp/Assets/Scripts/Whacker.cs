using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whacker : MonoBehaviour {
    public Vector3 force;

	void OnTriggerStay(Collider other)
    {
        if (Time.timeScale > .9f)
        {
            Debug.Log(other.gameObject);
            other.GetComponent<CharacterController>().Move(force*Time.deltaTime);
        }
    }

}
