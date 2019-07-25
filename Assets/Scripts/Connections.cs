using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connections : MonoBehaviour {

    [SerializeField]
    private int connections;
    [SerializeField]
    private List<GameObject> connectedNodes = new List<GameObject>();
    private int currentConnections = 0;

	void Awake () {
        setConnections();
	}
	
	public void setConnections()
    {
        int minConnections = Random.Range(1,3);
        int maxConnections = Random.Range(minConnections, 4);
        connections = Random.Range(minConnections, maxConnections);
    }

    public int getTotalConnections()
    {
        return connections;
    }

    public int getCurrentConnections()
    {
        return currentConnections;
    }

    public void addConnection(GameObject otherNode)
    {
        connectedNodes.Add(otherNode);
        currentConnections++;
    }

    public List<GameObject> getConnectedNodes()
    {
        return connectedNodes;
    }
}
