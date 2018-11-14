using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionChecker : MonoBehaviour {

    //the head collider is attached to the camera so it goes where the headset goes
    public bool isCollidingHead;

    private void OnTriggerEnter(Collider other)
    {
        isCollidingHead = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCollidingHead = false;
    }

}
