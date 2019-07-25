using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedToNetwork : MonoBehaviour {

    [SerializeField]
    private bool connectedToNetwork;
	// Use this for initialization
	void Awake () {
        connectedToNetwork = false;
	}
	
	public void setConnected(bool isConnected)
    {
        connectedToNetwork = isConnected;
    }

    public bool getConnected()
    {
        return connectedToNetwork;
    }
}
