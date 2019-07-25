using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkInUse : MonoBehaviour {

    [SerializeField]
    private bool inUse;

    public void setInUse()
    {
        inUse = true;
    }

    public void endUse()
    {
        inUse = false;
    }

    public bool getInUse()
    {
        return inUse;
    }
}
