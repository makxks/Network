using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    private float timer;
    private bool pushed = false;

    void Update()
    {
        timer += Time.deltaTime;

        if(pushed && timer > 3)
        {
            Application.Quit();
        }
    }

    public void quit()
    {
        GameObject.FindGameObjectWithTag("ClickNo").GetComponent<AudioSource>().Play();
        pushed = true;
        timer = 0;
    }
}
