using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalTimeMultiplier : MonoBehaviour {

    private float timeMultiplier;
    [SerializeField]
    private TimeDisplay time;
    [SerializeField]
    private RemainingPackets totalPackets;

	public void showTimeMultiplier()
    {
        GetComponent<Text>().text = "" + time.getTimeMultiplier(totalPackets.getTotalPackets());
    }
	
}
