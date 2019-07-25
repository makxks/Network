using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectsNodes : MonoBehaviour {

    [SerializeField]
    private List<GameObject> connectedNodes = new List<GameObject>();

    public void addNodes(GameObject node1, GameObject node2)
    {
        connectedNodes.Add(node1);
        connectedNodes.Add(node2);
    }

    public bool checkNodes(GameObject node)
    {
        return connectedNodes.Contains(node);
    }
}
