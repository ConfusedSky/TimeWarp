using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SlowDown : MonoBehaviour {
    void OnTriggerEnter()
    {
        TimeManagement.instance.SetTimeScale(1f);
    }
}
