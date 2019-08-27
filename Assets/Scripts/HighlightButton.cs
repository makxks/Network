using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightButton : MonoBehaviour
{
    [SerializeField]
    GameObject buttonImage;

    private void OnMouseEnter()
    {
        buttonImage.GetComponent<Animator>().SetBool("isHighlighted", true);
    }

    private void OnMouseExit()
    {
        buttonImage.GetComponent<Animator>().SetBool("isHighlighted", false);
    }
}
