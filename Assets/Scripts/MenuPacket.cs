using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPacket : MonoBehaviour {

    [SerializeField]
    private GameObject packet;
    private AudioSource confirm;

    void Start()
    {
        confirm = GameObject.FindGameObjectWithTag("ClickYes").GetComponent<AudioSource>();
    }

	public void moveToTarget(GameObject target)
    {
        confirm.Play();
        StartCoroutine(movePacket(packet, target));
    }

    public IEnumerator movePacket(GameObject packet, GameObject nodeToMoveTo)
    {
        float speed = 0.01f;
        float moveX = (nodeToMoveTo.transform.position.x - packet.transform.position.x);
        float moveY = (nodeToMoveTo.transform.position.y - packet.transform.position.y);
        float nodePosXUpper = nodeToMoveTo.transform.position.x + 1.5f;
        float nodePosXLower = nodeToMoveTo.transform.position.x - 1.5f;
        float nodePosYUpper = nodeToMoveTo.transform.position.y + 1.5f;
        float nodePosYLower = nodeToMoveTo.transform.position.y - 1.5f;
        while (!(
            packet.transform.position.x > nodePosXLower &&
            packet.transform.position.x < nodePosXUpper &&
            packet.transform.position.y > nodePosYLower &&
            packet.transform.position.y < nodePosYUpper
            ))
        {
            packet.transform.position = new Vector3(packet.transform.position.x + (speed * moveX), packet.transform.position.y + (speed * moveY), 0);
            yield return new WaitForFixedUpdate();
        }
    }
}
