using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMovement : MonoBehaviour {

    //Leap Rig
    public Transform vrCamera;

    public float speed = 2.0f;

    private bool isActive;

    //character controller is leap rig as you cannot move a vr camera you need to move parent.
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (isActive == true)
        {
            //Causes movement in the direction the headset is facing
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
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
