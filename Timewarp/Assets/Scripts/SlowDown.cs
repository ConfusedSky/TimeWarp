using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SlowDown : MonoBehaviour {
    //public GameObject box;
    public float time = 1f;

    void OnTriggerEnter()
    {
        TimeManagement.instance.SetTimeScale(1f);
        //Invoke("ActivateBox", time);
    }

    //void ActivateBox()
    //{
    //    box.SetActive(true);
    //}
}
