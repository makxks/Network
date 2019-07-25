using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartStandardGame : MonoBehaviour {

    private float timer;
    private bool pushed = false;
    private GameSettings gameSettings;

    private void Start()
    {
        gameSettings = GameObject.FindGameObjectWithTag("GameSettings").GetComponent<GameSettings>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (pushed && timer > 3)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void startStandard()
    {
        gameSettings.startStandardGame();
        pushed = true;
        timer = 0;
    }

    public void startCustomGame()
    {
        pushed = true;
        timer = 0;
    }
}
