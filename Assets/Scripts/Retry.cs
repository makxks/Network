using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

    private float timer;
    private bool pushed;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2 && pushed)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void retry()
    {
        GameObject.FindGameObjectWithTag("ClickYes").GetComponent<AudioSource>().Play();
        pushed = true;
        timer = 0;
    }
}
