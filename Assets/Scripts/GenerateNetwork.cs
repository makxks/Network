using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNetwork : MonoBehaviour {

    [SerializeField]
    private GameObject node;
    [SerializeField]
    private GameObject link;
    [SerializeField]
    private GameObject packet;
    private int numberOfNodes;
    private float length;
    private float height;
    private int packets;
    private List<GameObject> nodeList = new List<GameObject>();
    private List<GameObject> linkList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        packets = GameSettings.gameSettings.getPackets();
        height = (float)GameSettings.gameSettings.getHeight();
        length = (float)(height * 1.5f);
        numberOfNodes = (int)((length * height)/7500);
        generateNodes(numberOfNodes, length, height);
        GetComponent<GeneratePackets>().generatePackets(nodeList, packet, packets);
	}
	
    private void generateNodes(int nodes, float sizeX, float sizeY)
    {
        for(int i = 0; i< nodes; i++)
        {
            createNode(sizeX, sizeY);
        }
        for(int j = 0; j < nodeList.Count; j++)
        {
            createLinks(nodeList[j]);
        }
        connectAllNodesToNetwork();
    }

    private void createNode(float sizeX, float sizeY)
    {
        float xPos = Random.Range(-sizeX, sizeX);
        float yPos = Random.Range(-sizeY, sizeY);
        for(int i = 0; i < nodeList.Count; i++)
        {
            while(
                xPos > nodeList[i].transform.position.x - 50f &&
                xPos < nodeList[i].transform.position.x + 50f &&
                yPos > nodeList[i].transform.position.y - 50f &&
                yPos < nodeList[i].transform.position.y + 50f
                )
            {
                xPos = Random.Range(-sizeX, sizeX);
                yPos = Random.Range(-sizeY, sizeY);
            }
        }
        GameObject nodeClone = Instantiate(node, new Vector3(xPos, yPos, 0), Quaternion.identity);
        if(nodeList.Count == 0)
        {
            nodeClone.GetComponent<ConnectedToNetwork>().setConnected(true);
        }
        nodeList.Add(nodeClone);
    }

    private void createLinks(GameObject node)
    {
        int links = node.GetComponent<Connections>().getTotalConnections();
        for(int j=0; j<nodeList.Count; j++)
        {
            if(node.GetComponent<Connections>().getCurrentConnections() >= links)
            {
                break;
            }
            float chance = Random.Range(0.0f, 1.0f);
            if (nodeList[j] != node && nodeList[j].GetComponent<Connections>().getCurrentConnections() < nodeList[j].GetComponent<Connections>().getTotalConnections() && chance > 0.5f)
            {
                createLink(node, nodeList[j]);
                if (nodeList[j].GetComponent<ConnectedToNetwork>().getConnected())
                {
                    node.GetComponent<ConnectedToNetwork>().setConnected(true);
                }
                break;
            }
        }
    }

    private void connectUnconnectedNode(GameObject node)
    {
        for(int i=0; i<nodeList.Count; i++)
        {
            if (node.GetComponent<ConnectedToNetwork>().getConnected())
            {
                break;
            }
            float chance = Random.Range(0.0f, 1.0f);
            if(chance > 0.6f && nodeList[i] != node)
            {
                createLink(node, nodeList[i]);

                node.GetComponent<ConnectedToNetwork>().setConnected(true);
            }
        }
    }

    private void createLink(GameObject node1, GameObject node2)
    {
        GameObject linkClone = Instantiate(link);
        LineRenderer line = linkClone.GetComponent<LineRenderer>();
        line.SetPosition(0, node1.transform.position);
        line.SetPosition(1, node2.transform.position);
        line.startWidth = 2;
        line.endWidth = 2;
        node1.GetComponent<Connections>().addConnection(node2);
        node2.GetComponent<Connections>().addConnection(node1);
        line.GetComponent<ConnectsNodes>().addNodes(node1, node2);
        linkList.Add(line.gameObject);
        linkClone.GetComponent<LinkLength>().setLength(node1, node2);
    }

    public GameObject getLink(GameObject node1, GameObject node2)
    {
        for(int i = 0; i<linkList.Count; i++)
        {
            if(linkList[i].GetComponent<ConnectsNodes>().checkNodes(node1) && linkList[i].GetComponent<ConnectsNodes>().checkNodes(node2))
            {
                return linkList[i];
            }
        }
        return null;
    }

    private void connectAllNodesToNetwork()
    {
        for(int i=0; i<nodeList.Count; i++)
        {
            if (!nodeList[i].GetComponent<ConnectedToNetwork>().getConnected())
            {
                connectUnconnectedNode(nodeList[i]);
            }
        }
    }

    public float getLength()
    {
        return length;
    }

    public float getHeight()
    {
        return height;
    }
}
