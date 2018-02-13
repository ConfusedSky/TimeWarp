using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TimeManagement : MonoBehaviour {

    public static TimeManagement instance;
    public FirstPersonController player;
    public float defaultTime = .05f;

    private float playerScale = 0;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {

	}

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.timeScale == defaultTime)
                SetTimeScale(1f);
            else
                SetTimeScale(defaultTime);
        }
    }

    public void SetTimeScale(float scale)
    {
        playerScale = Time.timeScale / scale;
        Time.timeScale = scale;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        Invoke("UpdatePlayer", .05f*scale);
    }

    private void UpdatePlayer()
    {
        player.m_WalkSpeed *= playerScale;
        player.m_RunSpeed *= playerScale;
        player.m_JumpSpeed *= playerScale;
        player.m_GravityMultiplier *= playerScale * playerScale;
    }
}
