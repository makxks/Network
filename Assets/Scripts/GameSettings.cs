using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    [SerializeField]
    private int packets;
    [SerializeField]
    private int height;
    public static GameSettings gameSettings;

    void Awake()
    {
        if (gameSettings == null)
        {
            gameSettings = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (gameSettings != this)
        {
            Destroy(gameObject);
        }
    }

    public void startStandardGame()
    {
        setPackets(20);
        setHeight(300);
    }

    public int getPackets()
    {
        return packets;
    }

    public int getHeight()
    {
        return height;
    }

    public void setPackets(float packetsV)
    {
        packets = (int)packetsV;
    }

    public void setHeight(float heightV)
    {
        height = (int)heightV;
    }

}
