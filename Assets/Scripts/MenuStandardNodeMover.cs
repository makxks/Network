using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStandardNodeMover : MonoBehaviour {

    [SerializeField]
    float xSpeed;
    [SerializeField]
    float startXPos;
    float xRLimit = 8000;
    float xLLimit = -8000;
    float xPos;

    void Start()
    {
        xPos = startXPos;
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

	// Update is called once per frame
	void Update () {
	    if(transform.position.x > xRLimit)
        {
            transform.position = new Vector3(xLLimit, transform.position.y, transform.position.z);
        }
        if(transform.position.x < xLLimit)
        {
            transform.position = new Vector3(xRLimit, transform.position.y, transform.position.z);
        }

        xPos = transform.position.x + (xSpeed * Time.deltaTime);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
	}
}
