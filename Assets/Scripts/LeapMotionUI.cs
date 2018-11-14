using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapMotionUI : MonoBehaviour {

    private bool palmIsUpUI;
    private bool fingersExtendedUI;

    private bool attachedToPinky = true;

    public GameObject PinkyAnchor;

    public GameObject interactionCube;

    //TODO: after demo try and clean this code up so its in better places because
    //as of now the code is all over the place for different objects.
    //still need a way to move the anchor of the pinky more to the right of the hand so its not directly on the finger

    //all fingers extended for UIManager
    public void OnAllFingers()
    {
        fingersExtendedUI = !fingersExtendedUI;

        if (palmIsUpUI && fingersExtendedUI)
        {
            DisplayUI();
        }
        else
        {
            HideUI();
        }
    }

    //palm up for UIManager
    public void PalmDirectionChange()
    {
        palmIsUpUI = !palmIsUpUI;

        if (palmIsUpUI && fingersExtendedUI)
        {
            DisplayUI();
        }
        else
        {
            HideUI();
        }
       
    }

    //On attached and Detached are used when an item is anchored to the pinky (InteractionCube script)
    public void OnAttachedToHand()
    {
        attachedToPinky = true;
    }

    public void OnDetachedFromHand()
    {
        attachedToPinky = false;
    }


    //if attached, fingers extended and palm is up
    private void DisplayUI()
    {
        if (attachedToPinky)
        {
            interactionCube.SetActive(true);
        }
    }

    //any other hand state
    private void HideUI()
    {
        if (attachedToPinky)
        {
            interactionCube.SetActive(false);
        }
    }

}
