using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Packet : MonoBehaviour {

    [SerializeField]
    private float size;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject currentNode;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject packetChild;

    private RemainingPackets remPackets;

    private void Start()
    {
        remPackets = GameObject.FindGameObjectWithTag("GameController").GetComponent<RemainingPackets>();
    }

    public void initialisePacket(GameObject targetNode)
    {
        float chance = Random.Range(0.0f, 10.0f);
        if(chance < 6)
        {
            size = Random.Range(5.0f, 40.0f);
        }
        else if(chance < 9)
        {
            size = Random.Range(40.0f, 80.0f);
        }
        else
        {
            size = Random.Range(80.0f, 100.0f);
        }
        size = Mathf.Round(size);
        target = targetNode;
        speed = 15 / size;
        packetChild.SetActive(false);
    }

    public void setCurrentNode(GameObject node)
    {
        currentNode = node;
    }

    public float getSize()
    {
        return size;
    }

    public GameObject getTarget()
    {
        return target;
    }

    public GameObject getCurrentNode()
    {
        return currentNode;
    }

    public float getSpeed()
    {
        return speed;
    }

    public GameObject getPacketChild()
    {
        return packetChild;
    }

    public IEnumerator movePacket(GameObject packet, GameObject link, GameObject nodeToMoveTo)
    {
        link.GetComponent<LinkInUse>().setInUse();
        float speed = packet.GetComponent<Packet>().getSpeed();
        float moveX = (nodeToMoveTo.transform.position.x - packet.transform.position.x) / link.GetComponent<LinkLength>().getLength();
        float moveY = (nodeToMoveTo.transform.position.y - packet.transform.position.y) / link.GetComponent<LinkLength>().getLength();
        float nodePosXUpper = nodeToMoveTo.transform.position.x + 1.5f;
        float nodePosXLower = nodeToMoveTo.transform.position.x - 1.5f;
        float nodePosYUpper = nodeToMoveTo.transform.position.y + 1.5f;
        float nodePosYLower = nodeToMoveTo.transform.position.y - 1.5f;
        if(remPackets.getPackets() == 1 && packet.GetComponent<Packet>().target == nodeToMoveTo)
        {
            Time.timeScale = 2;
        }
        while (!(
            packet.transform.position.x > nodePosXLower &&
            packet.transform.position.x < nodePosXUpper && 
            packet.transform.position.y > nodePosYLower &&
            packet.transform.position.y < nodePosYUpper
            ))
        {
            packet.transform.position = new Vector3(packet.transform.position.x + (speed * moveX), packet.transform.position.y + (speed * moveY), 0);
            yield return new WaitForFixedUpdate();
        }
        link.GetComponent<LinkInUse>().endUse();
        packetArrives(nodeToMoveTo, packet);
        if(Time.timeScale > 1)
        {
            Time.timeScale = 1;
        }
    }

    public void packetArrives(GameObject node, GameObject packet)
    {
        SelectNode selectNode = GameObject.FindGameObjectWithTag("GameController").GetComponent<SelectNode>();
        SelectPacket selectPacket = GameObject.FindGameObjectWithTag("GameController").GetComponent<SelectPacket>();

        bool reselectNode = false;
        bool reselectPacket = false;
        ReferencedPacket packetToReset = null;

        if (selectNode.getSelectedNode() == node)
        {
            reselectNode = true;
            if (selectPacket.getSelectedPacket())
            {
                packetToReset = selectPacket.getReferencedPacket();
                reselectPacket = true;
            }
        }

        GameObject.FindGameObjectWithTag("PacketArrive").GetComponent<AudioSource>().Play();
        node.GetComponent<Packets>().addPacket(packet); // add packet to the new node
        node.GetComponent<Packets>().checkPacketTargets(); // destroy packet if it has reached the target
        packet.GetComponent<Packet>().getPacketChild().SetActive(false);
        if (node.GetComponent<Packets>().getPacketCount() == 0)
        {
            node.GetComponentInChildren<Text>().text = "";
        }
        else
        {
            node.GetComponentInChildren<Text>().text = "" + node.GetComponent<Packets>().getPacketCount();//update packet count on arrival node
        }
        if (reselectNode)
        {
            //selectNode.selectNode(selectNode.getSelectedNode());// reselect currently selected node -- unneccesary now, so commented
            if (reselectPacket)
            {
                selectPacket.setSelectedPacket(packetToReset);
                selectPacket.resetDisplays(packetToReset);
            }
        }
        //if the arrived at node is selected it does not show the updated packet information without being reselected
    }

}
