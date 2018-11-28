﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMovement : MonoBehaviour {

   //all currently only for use with right hand

    public float speed = 2.0f;

    private bool isActive;

    private HeadCollisionChecker headCollisionChecker;

    private Camera vrCamera;

    private void Start()
    {
        vrCamera = Camera.main;
        headCollisionChecker = vrCamera.GetComponent<HeadCollisionChecker>();
    }

    private void FixedUpdate()
    {
        if (isActive == true)
        {
            if (headCollisionChecker.isCollidingHead != true)
            {
                //only moves on the cameras x and z forward not y
                float cameraForwardZ = Camera.main.transform.forward.z;
                float cameraForwardX = Camera.main.transform.forward.x;

                transform.position = transform.position + new Vector3(cameraForwardX, 0, cameraForwardZ) * speed * Time.deltaTime;
            }
            else
            {
                //allows foot collision not to get the player stuck (is not the greatest method for vr but works)
                gameObject.transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z - 0.1f);
            }
	
        }
    }

    //only activates when index and thumb extended
    public void ExtendedFingerMovementVR()
    {
        isActive = true;
    }

    public void ExtendedFingerMovementEnd()
    {
        isActive = false;
    }
}
