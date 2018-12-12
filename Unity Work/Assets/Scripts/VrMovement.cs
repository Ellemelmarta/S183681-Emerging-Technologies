using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMovement : MonoBehaviour {

    public float speed;

    private bool isMovementActive;
    private bool isColliding;

    private HeadCollisionChecker headCollisionChecker;

    private void Start()
    {
        headCollisionChecker = Camera.main.GetComponent<HeadCollisionChecker>();
    }

    private void FixedUpdate()
    {
        //Player has to walk back if they collide with a wall
        if (headCollisionChecker.isCollidingHead == true)
        {
            isColliding = true;
        }
        else if (headCollisionChecker.isCollidingHead == false)
        {
            isColliding = false;
            if (isMovementActive == true && isColliding == false)
            {
                //Camera will only move on x and z
                float cameraForwardZ = Camera.main.transform.forward.z;
                float cameraForwardX = Camera.main.transform.forward.x;

                //Cannot move the virtual reality camera only the parent gameObject of it (moving the LeapRig)
                transform.position = transform.position + new Vector3(cameraForwardX, 0, cameraForwardZ) * speed * Time.deltaTime;
            }
        }
    }

    //Activation on bottom 3 fingers on right hand being extended
    public void ExtendedFingerMovementVR()
    {
        isMovementActive = true;
    }

    public void ExtendedFingerMovementEnd()
    {
        isMovementActive = false;
    }
}
