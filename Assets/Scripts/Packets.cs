using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Packets : MonoBehaviour {

    [SerializeField]
    private List<GameObject> packets = new List<GameObject>();
    private TimeDisplay time;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            time = GameObject.FindGameObjectWithTag("Time").GetComponent<TimeDisplay>();
        }
    }

    public void addPacket(GameObject packet)
    {
        packet.GetComponent<Packet>().setCurrentNode(this.gameObject);
        packets.Add(packet);
    }

    public int getPacketCount()
    {
        return packets.Count;
    }

    public List<GameObject> getPackets()
    {
        return packets;
    }

    public void checkPacketTargets()
    {
        for(int i=0; i<packets.Count; i++)
        {
            if (packets[i].GetComponent<Packet>().getTarget() == this.gameObject)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<RemainingPackets>().updatePacketNumber(-1);
                GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().increaseScore(packets[i].GetComponent<Packet>().getSize()); //score increased by size of packet
                packets.Remove(packets[i]);
            }
        }
        if(GameObject.FindGameObjectWithTag("GameController").GetComponent<RemainingPackets>().getPackets() == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                time.setGameComplete(true);
            }
            ShowFinalScore finalScore = GameObject.FindGameObjectWithTag("FinalScore").GetComponent<ShowFinalScore>();
            FinalScore score = GameObject.FindGameObjectWithTag("Score").GetComponent<FinalScore>();
            score.calculateFinalScore();
            StartCoroutine(finalScore.showScore());
        }
    }

    public void removePacket(GameObject packet)
    {
        packets.Remove(packet);
    }
}
