using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour {

    public void menuMove(GameObject target)
    {
        StartCoroutine(moveCamera(target));
    }

    public IEnumerator moveCamera(GameObject nodeToMoveTo)
    {
        float speed = 0.01f;
        float moveX = (nodeToMoveTo.transform.position.x - this.gameObject.transform.position.x);
        float moveY = (nodeToMoveTo.transform.position.y - this.gameObject.transform.position.y);
        float nodePosXUpper = nodeToMoveTo.transform.position.x + 1.5f;
        float nodePosXLower = nodeToMoveTo.transform.position.x - 1.5f;
        float nodePosYUpper = nodeToMoveTo.transform.position.y + 1.5f;
        float nodePosYLower = nodeToMoveTo.transform.position.y - 1.5f;
        while (!(
            this.gameObject.transform.position.x > nodePosXLower &&
            this.gameObject.transform.position.x < nodePosXUpper &&
            this.gameObject.transform.position.y > nodePosYLower &&
            this.gameObject.transform.position.y < nodePosYUpper
            ))
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + (speed * moveX), this.gameObject.transform.position.y + (speed * moveY), -50);
            yield return new WaitForFixedUpdate();
        }
    }
}
