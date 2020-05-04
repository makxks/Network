using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private float zoom = 100;
    private float minZoom = 25;
    private float maxZoom = 300;
    private GenerateNetwork generator;
    private PauseGame pause;

    private bool touching;
    private float touchTimer;
    private Vector2 start;

    void Start()
    {
        pause = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseGame>();
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<GenerateNetwork>();
        touching = false;
        touchTimer = 0;
        start = Vector2.zero;
    }

	// Update is called once per frame
	void Update () {
        if (!pause.getPaused())
        {/*
            if (touching)
            {
                touchTimer += Time.deltaTime;
            }

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touching = true;
                        start = touch.position;
                        break;

                    case TouchPhase.Moved:
                        float xDiff = start.x - touch.position.x;
                        float yDiff = start.y - touch.position.y;

                        Camera.main.transform.position = new Vector3((Camera.main.transform.position.x + xDiff / 40), (Camera.main.transform.position.y + yDiff / 40), -10);

                        if(Camera.main.transform.position.x > generator.getLength())
                        {
                            Camera.main.transform.position = new Vector3(generator.getLength(), Camera.main.transform.position.y, -10);
                        }
                        else if (Camera.main.transform.position.x < -generator.getLength())
                        {
                            Camera.main.transform.position = new Vector3(-generator.getLength(), Camera.main.transform.position.y, -10);
                        }

                        if (Camera.main.transform.position.y > generator.getHeight())
                        {
                            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, generator.getHeight(), -10);
                        }
                        else if (Camera.main.transform.position.y < -generator.getHeight())
                        {
                            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, -generator.getHeight(), - 10);
                        }
                        break;

                    case TouchPhase.Ended:
                        touchTimer = 0;
                        touching = false;
                        break;
                }
            }

            if (Input.touchCount == 2)
            {
                // Store both touches.
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                // Find the position in the previous frame of each touch.
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // Find the magnitude of the vector (the distance) between the touches in each frame.
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                // Find the difference in the distances between each frame.
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                float zoomSpeedMod = 25;

                float zoomSpeed = (deltaMagnitudeDiff * zoomSpeedMod) / 100;

                if(deltaMagnitudeDiff < 0)
                {
                    zoom = Mathf.Max(Camera.main.orthographicSize + zoomSpeed, minZoom);
                }
                else if(deltaMagnitudeDiff > 0)
                {
                    zoom = Mathf.Min(Camera.main.orthographicSize + zoomSpeed, maxZoom);
                }
            }*/
            
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                //
                zoom = Mathf.Max(Camera.main.orthographicSize - 10, minZoom);
            }
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                //
                zoom = Mathf.Min(Camera.main.orthographicSize + 10, maxZoom);
            }
            
            Camera.main.orthographicSize = zoom;

            /*if (touchTimer > 0.2f)
            {
            */
                // ** for PC build controls **
                moveToMouse();

            /*
        }
            */
        }
    }

    private void moveToMouse()
    {
        Vector3 pos;
        float xDiff = 0;
        float yDiff = 0;
        //
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));

        if (pos.x > generator.getLength())
        {
            xDiff = generator.getLength() - Camera.main.transform.position.x;
        }
        else if (pos.x < -generator.getLength())
        {
            xDiff = -generator.getLength() - Camera.main.transform.position.x;
        }
        else
        {
            if (pos.x - Camera.main.transform.position.x > 125 || pos.x - Camera.main.transform.position.x < -125)
            {
                xDiff = pos.x - Camera.main.transform.position.x;
            }
            else
            {
                xDiff = 0;
            }
        }
        if (pos.y > generator.getHeight())
        {
            yDiff = generator.getHeight() - Camera.main.transform.position.y;
        }
        else if (pos.y < -generator.getHeight())
        {
            yDiff = -generator.getHeight() - Camera.main.transform.position.y;
        }
        else
        {
            if (pos.y - Camera.main.transform.position.y > 85 || pos.y - Camera.main.transform.position.y < -85)
            {
                yDiff = pos.y - Camera.main.transform.position.y;
            }
            else
            {
                yDiff = 0;
            }
        }
        Camera.main.transform.position = new Vector3((Camera.main.transform.position.x + xDiff/50), (Camera.main.transform.position.y + yDiff/50), -10);
    }

    public float getZoom()
    {
        return zoom;
    }

}
