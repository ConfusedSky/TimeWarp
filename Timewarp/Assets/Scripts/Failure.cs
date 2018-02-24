using UnityEngine;
using UnityEngine.SceneManagement;

public class Failure : MonoBehaviour
{
    public Fade fade;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            FailImmediate();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BringMenu();
        }
    }

    public void FailImmediate()
    {
        TimeManagement.instance.SetTimeScale(1f);
        Reload();
    }

	public void Fail()
	{
        TimeManagement.instance.SetTimeScale(1f);
        fade.fadeSpeed = .15f;
        fade.FadeOut(Reload);
	}

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


    private float timeScale = 0;
    private bool menuOn = false;
    public GameObject menu;
    public MonoBehaviour[] inputSources;
    public GunGun gg;

    public void BringMenu()
    {
        if(!menuOn)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.None;

            timeScale = Time.timeScale;
            Time.timeScale = 0f;
            foreach(MonoBehaviour go in inputSources)
            {
                go.enabled = false;
            }
            gg.enabled = false;
            menu.SetActive(true);
            menuOn = true;
        }
        else
        {
            Cursor.visible = false;

            Time.timeScale = timeScale;
            foreach (MonoBehaviour go in inputSources)
            {
                go.enabled = true;
            }
            gg.enabled = true;
            menu.SetActive(false);
            menuOn = false;
        }
    }

    public void Restart()
    {
        CheckpointManager.UpdateCheckpoint((new GameObject()).transform);
        FailImmediate();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
