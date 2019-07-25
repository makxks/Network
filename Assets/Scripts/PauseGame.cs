using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu;
    private bool paused = false;

    void Start()
    {
        pauseMenu.transform.position = new Vector3(5000, 5000, -9);
    }

	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (paused)
            {
                unpause();
            }
            else if (!paused)
            {
                pause();
            }
        }
	}

    public void pause()
    {
        GameObject.FindGameObjectWithTag("ClickYes").GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
        paused = true;
        pauseMenu.transform.localPosition = new Vector3(0, 0, 1);
    }

    public void unpause()
    {
        GameObject.FindGameObjectWithTag("ClickNo").GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        paused = false;
        pauseMenu.transform.localPosition = new Vector3(5000, 5000, -9);
    }

    public bool getPaused()
    {
        return paused;
    }
}
