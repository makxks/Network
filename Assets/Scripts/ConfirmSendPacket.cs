using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmSendPacket : MonoBehaviour {

    [SerializeField]
    private PanelNodeAndPacket nodePacket;
    [SerializeField]
    private GameObject confirmUI;

	public void send()
    {
        nodePacket.sendPacket(nodePacket, confirmUI);
    }
}
