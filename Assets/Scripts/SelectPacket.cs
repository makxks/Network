using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPacket : MonoBehaviour {

    [SerializeField]
    private GameObject selectedPacket;
    private ReferencedPacket referencedPacket;
    private static GameObject selectedButton;
	
	public void setSelectedPacket(ReferencedPacket packet)
    {
        GameObject.FindGameObjectWithTag("ClickYes").GetComponent<AudioSource>().Play();
        if(selectedButton && selectedButton != this)
        {
            selectedButton.GetComponent<Image>().color = Color.white;
        }
        if(selectedPacket && selectedPacket != this)
        {
            selectedPacket.GetComponent<Packet>().getTarget().GetComponent<Animators>().getTargetAnimator().SetBool("isTarget", false);
        }
        if(packet)
        {
            selectedButton = packet.gameObject;
            selectedPacket = packet.getReferencedPacket();
            selectedButton.GetComponent<Image>().color = Color.black;
            selectedPacket.GetComponent<Packet>().getTarget().GetComponent<Animators>().getTargetAnimator().SetBool("isTarget", true);
            referencedPacket = packet;
        }
        else
        {
            selectedPacket = null;
        }
    }

    public GameObject getSelectedButton()
    {
        return selectedButton;
    }

    public GameObject getSelectedPacket()
    {
        return selectedPacket;
    }

    public ReferencedPacket getReferencedPacket()
    {
        return referencedPacket;
    }

    public void resetDisplays(ReferencedPacket packet)
    {
        selectedButton = packet.gameObject;
        selectedButton.GetComponent<Image>().color = Color.black;
        selectedPacket.GetComponent<Packet>().getTarget().GetComponent<Animators>().getTargetAnimator().SetBool("isTarget", true);
    }
}
