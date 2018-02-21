using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnable : MonoBehaviour {

    public GunGun gg;

    void OnTriggerEnter()
    {
        gg.MakeEnable();
        gameObject.SetActive(false);
    }
}
