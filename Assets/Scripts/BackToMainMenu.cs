using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour {
    

    public void backToMenuButton()
    {       
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("ClickNo").GetComponent<AudioSource>().Play();
        SceneManager.LoadSceneAsync(0);
    }
}
