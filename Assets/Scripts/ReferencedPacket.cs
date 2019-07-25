using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencedPacket : MonoBehaviour {

    [SerializeField]
    private GameObject referencedPacket;
	
    public void setReferencedPacket(GameObject packet)
    {
        referencedPacket = packet;
    }

    public GameObject getReferencedPacket()
    {
        if (referencedPacket)
        {
            return referencedPacket;
        }
        else
        {
            return null;
        }
    }
}
