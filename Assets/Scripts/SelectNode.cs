using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectNode : MonoBehaviour {
    
    private static GameObject selected;
    [SerializeField]
    private GameObject packetButton;
    [SerializeField]
    private GameObject packetPanel;
    [SerializeField]
    private GameObject sendOrSelectPanel;
    List<GameObject> packetButtons = new List<GameObject>();
    CameraControl cameraMain;

    void Start()
    {
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
        packetPanel.transform.position = new Vector3(10000, 20000, 0);
    }

    void Update()
    {
        if (selected)
        {
            packetPanel.transform.localScale = new Vector3(cameraMain.getZoom() / 100, cameraMain.getZoom() / 100, 1);
            packetPanel.transform.position = new Vector3(selected.transform.position.x - 100 * (cameraMain.getZoom() / 150), selected.transform.position.y, -9);
        }
    }
	
	public void select(GameObject clicked)
    {
        GameObject.FindGameObjectWithTag("ClickYes").GetComponent<AudioSource>().Play();
        if (GetComponent<SelectPacket>().getSelectedPacket() && selected.GetComponent<Connections>().getConnectedNodes().Contains(clicked))
        {
            sendOrSelectPanel.SetActive(true);
            sendOrSelectPanel.GetComponentInParent<PanelNodeAndPacket>().setNode(clicked);
            sendOrSelectPanel.GetComponentInParent<PanelNodeAndPacket>().setPacket(GetComponent<SelectPacket>().getSelectedPacket());
        }
        else
        {
            selectNode(clicked);
            sendOrSelectPanel.SetActive(false);
        }
    }

    public GameObject getSelectedNode()
    {
        return selected;
    }

	public void selectNode (GameObject clicked) {
        if (selected && selected != clicked)
        {
            selected.GetComponent<Animators>().getActiveAnimator().SetBool("isActiveNode", false);
            setConnectedNodes(selected.GetComponent<Connections>().getConnectedNodes(), false);
        }
        selected = clicked;
        selected.GetComponent<Animators>().getActiveAnimator().SetBool("isActiveNode", true);
        GetComponent<SelectPacket>().setSelectedPacket(null);
        if(selected.GetComponent<Packets>().getPacketCount() == 0)
        {
            selected.GetComponentInChildren<Text>().text = "";
        }
        else
        {
            selected.GetComponentInChildren<Text>().text = "" + selected.GetComponent<Packets>().getPacketCount();
        }
        setConnectedNodes(selected.GetComponent<Connections>().getConnectedNodes(), true);
        displayPacketDetails(selected.GetComponent<Packets>().getPackets());
    }

    private void setConnectedNodes(List<GameObject> nodes, bool isConnected)
    {
        for(int i=0; i<nodes.Count; i++)
        {
            nodes[i].GetComponent<Animators>().getButtonImageAnimator().SetBool("isConnected", isConnected);
        }
    }

    private void displayPacketDetails(List<GameObject> packets)
    {
        removeAllPacketDetails();
        for (int i = 0; i < packets.Count; i++)
        {
            GameObject buttonClone = Instantiate(packetButton);
            buttonClone.GetComponent<ReferencedPacket>().setReferencedPacket(packets[i]);
            packetButtons.Add(buttonClone);
            buttonClone.transform.SetParent(packetPanel.transform, false);
            buttonClone.transform.localPosition = new Vector2(0, 150 - (40 * (i + 1)));
            buttonClone.transform.localScale = new Vector3(1, 1, 1);
            Text[] texts = new Text[0];
            texts = buttonClone.GetComponentsInChildren<Text>();
            texts[0].text = "" + i;
            texts[1].text = "" + packets[i].GetComponent<Packet>().getSize();
        }
    }

    private void removeAllPacketDetails()
    {
        if (packetButtons.Count > 0)
        {
            for (int i = 0; i < packetButtons.Count; i++)
            {
                Destroy(packetButtons[i]);
            }
        }
    }
}
