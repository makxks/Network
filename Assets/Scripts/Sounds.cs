using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour {

    private int packets;
    private int height;
    public static Sounds sounds;
    private float volume = 0.5f;
    Slider volumeSlider;

    void Awake()
    {
        volumeSlider = GameObject.FindGameObjectWithTag("VolumeSlider").GetComponent<Slider>();
        if (sounds == null)
        {
            sounds = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (sounds != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        volumeSlider.value = volume;
    }

    public void changeVolume(float newVolume)
    {
        AudioSource[] musicAndSounds = GetComponentsInChildren<AudioSource>();
        for(int i = 0; i<musicAndSounds.Length; i++)
        {
            musicAndSounds[i].volume = newVolume;
        }
        volume = newVolume;
        GameObject.FindGameObjectWithTag("ClickYes").GetComponent<AudioSource>().Play();
    }
    
    public void playSoundsEffect(AudioSource soundEffect)
    {
        soundEffect.Play();
    }

    public void setVolume(float newVolume)
    {
        volume = newVolume;
    }

    public float getVolume()
    {
        return volume;
    }
}
