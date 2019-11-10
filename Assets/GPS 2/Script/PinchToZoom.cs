using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    private float startDistance = 0f;
    private float pinchDelta = 0f;
    private float zoomSensitivity = 0f;
    public float decayRate = 5f;

    void Update()
    {
        //Use touch input to zoom in/out
        GetPinchDelta();
        Zoom();

    }

    private void Zoom()
    {
        this.transform.Translate(0, 0, pinchDelta * Time.deltaTime * zoomSensitivity, Space.Self);
        pinchDelta = Mathf.Lerp(pinchDelta, 0f, Time.deltaTime * decayRate);
    }

    /// <summary>
    /// Gets Pinch delta
    /// Compares two finger distances over time
    /// </summary>

    void GetPinchDelta()
    {


        //We begin working when the second finger caresses the beautiful sexy mobile screen
        if (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began)
            startDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

        //Start calculating current distance over time when either fingers have moved
        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                float curDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

                pinchDelta = curDistance - startDistance;
                pinchDelta /= startDistance;
            }
        }
    }
}
