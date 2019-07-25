using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratePackets : MonoBehaviour {

	public void generatePackets(List<GameObject> nodes, GameObject packet, int numberOfPackets)
    {

        RemainingPackets remainingPackets = GameObject.FindGameObjectWithTag("GameController").GetComponent<RemainingPackets>();
        remainingPackets.setPackets(numberOfPackets);
        for (int i=0; i<numberOfPackets; i++)
        {
            int randomStartNode = Random.Range(0, nodes.Count);
            while (nodes[randomStartNode].GetComponent<Packets>().getPacketCount() > 6)
            {
                randomStartNode = Random.Range(0, nodes.Count);
            }
            int randomTargetNode = Random.Range(0, nodes.Count);
            while(randomStartNode == randomTargetNode)
            {
                randomTargetNode = Random.Range(0, nodes.Count);
            }
            GameObject packetClone = Instantiate(packet);
            nodes[randomStartNode].GetComponent<Packets>().addPacket(packetClone);
            packetClone.transform.position = nodes[randomStartNode].transform.position;
            packetClone.GetComponent<Packet>().initialisePacket(nodes[randomTargetNode]);
            packetClone.GetComponent<Packet>().setCurrentNode(nodes[randomStartNode]);
        }

        for(int i=0; i<nodes.Count; i++)
        {
            if (nodes[i].GetComponent<Packets>().getPacketCount() == 0)
            {
                nodes[i].GetComponentInChildren<Text>().text = "";
            }
            else
            {
                nodes[i].GetComponentInChildren<Text>().text = "" + nodes[i].GetComponent<Packets>().getPacketCount();
            }
        }
        remainingPackets.setTotalPackets(numberOfPackets);
    }
}
