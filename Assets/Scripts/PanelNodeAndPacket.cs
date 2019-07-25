using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelNodeAndPacket : MonoBehaviour {

    private GameObject node;
    private GameObject packet;
    [SerializeField]
    private Text packetFailedMessage;
    [SerializeField]
    private GameObject packetFailedPanel;

    public void setNode(GameObject selectedNode)
    {
        node = selectedNode;
    }

    public void setPacket(GameObject selectedPacket)
    {
        packet = selectedPacket;
    }

    public GameObject getNode()
    {
        return node;
    }

    public GameObject getPacket()
    {
        return packet;
    }

    public void sendPacket(PanelNodeAndPacket nodePacket, GameObject confirmUI)
    {
        string message = "";
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        GameObject node = nodePacket.getNode();
        GameObject packet = nodePacket.getPacket();
        GameObject link = GameObject.FindGameObjectWithTag("Generator").GetComponent<GenerateNetwork>().getLink(node, packet.GetComponent<Packet>().getCurrentNode());
        LinkInUse used = link.GetComponent<LinkInUse>();
        if (!used.getInUse() && node.GetComponent<Packets>().getPacketCount() < 6)
        {
            packet.GetComponent<Packet>().getCurrentNode().GetComponent<Packets>().removePacket(packet); //remove packet from the packets on the node it is leaving
            gameController.GetComponent<SelectNode>().selectNode(packet.GetComponent<Packet>().getCurrentNode()); //reselect current node to show updated information
            packet.GetComponent<Packet>().getPacketChild().SetActive(true);
            StartCoroutine(packet.GetComponent<Packet>().movePacket(packet, link, node));
            packetFailedMessage.text = "";
            GameObject.FindGameObjectWithTag("ClickYes").GetComponent<AudioSource>().Play();
        }
        else
        {
            if (used.getInUse())
            {
                message += "Link currently in use. ";
            }
            if (node.GetComponent<Packets>().getPacketCount() >= 6)
            {
                message += "Selected node has reached capacity.";
            }
            packetFailedPanel.gameObject.SetActive(true);
            packetFailedMessage.text = message;
            GameObject.FindGameObjectWithTag("ClickNo").GetComponent<AudioSource>().Play();          
        }
        confirmUI.gameObject.SetActive(false);
    }
}
