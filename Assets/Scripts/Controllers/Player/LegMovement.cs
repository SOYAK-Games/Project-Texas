using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
    private Vector3 legRotation = new Vector3(0, 0, 0);

    private void Update()
    {
        LegDirection();
    }

    // Update is called once per frame
    private void LegDirection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            legRotation = new Vector3(0, 0, 90);
            transform.eulerAngles = legRotation;
        }

        if (Input.GetKey(KeyCode.S))
        {
            legRotation = new Vector3(0, 0, 270);
            transform.eulerAngles = legRotation;
        }

        if (Input.GetKey(KeyCode.A))
        {
            legRotation = new Vector3(0, 0, 180);
            transform.eulerAngles = legRotation;
        }
		
        if (Input.GetKey(KeyCode.D))
        {
            legRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = legRotation;
        }
        if(Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.D))
        {
            legRotation = new Vector3(0, 0, 45);
            transform.eulerAngles = legRotation;
        }
        if(Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.A))
        {
            legRotation = new Vector3(0, 0, 135);
            transform.eulerAngles = legRotation;
        }
        if(Input.GetKey(KeyCode.S)&& Input.GetKey(KeyCode.A))
        {
            legRotation = new Vector3(0, 0, 225);
            transform.eulerAngles = legRotation;
        }
        if(Input.GetKey(KeyCode.S)&& Input.GetKey(KeyCode.D))
        {
            legRotation = new Vector3(0, 0, 315);
            transform.eulerAngles = legRotation;
        }
    }
}
