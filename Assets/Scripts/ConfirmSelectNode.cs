using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmSelectNode : MonoBehaviour {

    [SerializeField]
    private GameObject confirmPanel;

	public void confirmSelectNode()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameController.GetComponent<SelectNode>().selectNode(GetComponentInParent<PanelNodeAndPacket>().getNode());
        confirmPanel.SetActive(false);
    }
}
