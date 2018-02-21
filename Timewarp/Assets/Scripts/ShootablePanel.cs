using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootablePanel : MonoBehaviour, IShootable {
    public Animation animation;
    public Whacker whacker;
    public bool alwaysShoot;

    private bool played = false;

    public void OnShot()
    {
        if (alwaysShoot || !played)
        {
            animation.Play();
            played = true;

            Invoke("invokeWhacker", .23f);
        }
    }

    void invokeWhacker()
    {
        whacker.Activate();
    }
}
