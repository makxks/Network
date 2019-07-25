using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animators : MonoBehaviour {

    [SerializeField]
    private Animator activeNode;
    [SerializeField]
    private Animator target;
    [SerializeField]
    private Animator connectedNode;

    public Animator getActiveAnimator()
    {
        return activeNode;
    }

    public Animator getTargetAnimator()
    {
        return target;
    }

    public Animator getConnectedAnimator()
    {
        return connectedNode;
    }
}
