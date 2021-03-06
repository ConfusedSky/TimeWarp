﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CheckpointManager
{
    private static Vector3 checkpointPosition;
    private static Quaternion checkpointRotation;
    private static bool gungunActive = false;

    public static void UpdateCheckpoint(Transform checkpoint)
    {
        checkpointPosition = checkpoint.position;
        checkpointRotation = checkpoint.rotation;
    }

    public static void MoveToCheckpoint(GameObject g)
    {
        if (checkpointPosition != new Vector3())
        {
            g.transform.position = checkpointPosition;
            // This is hacky I know, but I don't have the time to do it right
            GameObject temp = new GameObject();
            temp.transform.rotation = checkpointRotation;
            g.GetComponent<FirstPersonController>().SetRotation(temp.transform);
            Object.Destroy(temp);

            Debug.Log("Gungunactive: " + gungunActive);
            GunGun gg = g.GetComponent<GunGun>();
            if (gg != null && gungunActive)
                gg.Invoke("MakeEnable", .5f);
        }

    }

    public static void GunActive()
    {
        gungunActive = true;
    }
}
