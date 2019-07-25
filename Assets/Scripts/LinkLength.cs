using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkLength : MonoBehaviour {

    [SerializeField]
    private float linkLength;
    [SerializeField]
    private float xDist;
    [SerializeField]
    private float yDist;
	
    public void setLength(GameObject node1, GameObject node2)
    {
        xDist = node1.transform.position.x - node2.transform.position.x;
        yDist = node1.transform.position.y - node2.transform.position.y;
        linkLength = Mathf.Sqrt((xDist * xDist) + (yDist * yDist));
    }

    public float getLength()
    {
        return linkLength;
    }
}
