using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingPackets : MonoBehaviour {

    private int packets = 0;
    private int totalPackets;

    public void updatePacketNumber(int change)
    {
        packets += change;
    }

    public void setPackets(int newPacketNumber)
    {
        packets = newPacketNumber;
    }

    public int getPackets()
    {
        return packets;
    }

    public void setTotalPackets(int packets)
    {
        totalPackets = packets;
    }

    public int getTotalPackets()
    {
        return totalPackets;
    }
}
