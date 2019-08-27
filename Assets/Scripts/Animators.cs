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
    [SerializeField]
    private Animator buttonImageAnimator;

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

    public Animator getButtonImageAnimator()
    {
        return buttonImageAnimator;
    }
}
