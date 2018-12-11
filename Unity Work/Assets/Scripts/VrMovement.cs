using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMovement : MonoBehaviour {

   //all currently only for use with right hand

    public float speed = 2.0f;

    private bool isActive;
    private bool isColliding;

    private HeadCollisionChecker headCollisionChecker;

    private Camera vrCamera;

    private void Start()
    {
        vrCamera = Camera.main;
        headCollisionChecker = vrCamera.GetComponent<HeadCollisionChecker>();
    }

    private void FixedUpdate()
    {
        if (headCollisionChecker.isCollidingHead == true)
        {
            print("it does work");
            //allows foot collision not to get the player stuck (is not the greatest method for vr but works)
            isColliding = true;

            //now i need a way to move the player away from the wall but im not really sure how tf to do this to be honest so maybe this code will all be irellivant soon enough

        }
        else if (headCollisionChecker.isCollidingHead == false)
        {
            print("this works too");
            isColliding = false;
            if (isActive == true && isColliding == false)
            {
                //only moves on the cameras x and z forward not y
                float cameraForwardZ = Camera.main.transform.forward.z;
                float cameraForwardX = Camera.main.transform.forward.x;
                transform.position = transform.position + new Vector3(cameraForwardX, 0, cameraForwardZ) * speed * Time.deltaTime;
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
