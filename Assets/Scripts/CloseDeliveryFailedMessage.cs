using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDeliveryFailedMessage : MonoBehaviour {

    [SerializeField]
    private GameObject deliveryFailedPanel;

    void Start()
    {
        deliveryFailedPanel.SetActive(false);
    }

    public void closePanel()
    {
        deliveryFailedPanel.SetActive(false);
    }
}
