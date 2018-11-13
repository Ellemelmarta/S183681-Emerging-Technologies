using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrMovement : MonoBehaviour {

   //all currently only for use with right hand

    public float speed = 2.0f;

    private bool isActive;
	
    private void FixedUpdate()
    {
        if (isActive == true)
        {
			//if (nothing is overlapping collider) {}
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
		
			//else , dont move cos youre hitting into a wall etc
			
            //cc.SimpleMove(forward * speed);
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
