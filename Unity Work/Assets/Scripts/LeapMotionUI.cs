using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Attributes;
using Leap.Unity.Interaction;

public class LeapMotionUI : MonoBehaviour {

    private bool palmIsUpUI;
    private bool fingersExtendedUI;

    private bool attachedToPinky = true;
    private AnchorableBehaviour anchorableBehaviour;

    public GameObject uiPad;
    
    public GameObject interactionCube;
    public GameObject uiHandAnchor;

    private void Start()
    {
        //Allows for attatchment to the anchor
        anchorableBehaviour = interactionCube.GetComponent<AnchorableBehaviour>();
    }


    //All fingers extended
    public void OnAllFingers()
    {
        fingersExtendedUI = !fingersExtendedUI;

        if (palmIsUpUI && fingersExtendedUI)
        {
            DisplayInteractionCube();
        }
        else
        {
            HideUI();
        }
    }

    //Palm facing up
    public void PalmDirectionChange()
    {
        //Starts as false
        palmIsUpUI = !palmIsUpUI;

        //Conditions for displaying the UI
        if (palmIsUpUI && fingersExtendedUI)
        {
            DisplayInteractionCube();
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
        DisplayUI();
    }

    public void OnDetachedFromHand()
    {
        attachedToPinky = false;
        DisplayUI();
    }


    private void DisplayUI()
    {
        //Uipad is attached to the camera as using camera position doesn't work
        if (attachedToPinky == true)
        {
            uiPad.SetActive(false);
        }
        else
        {
            uiPad.SetActive(true);
        }
    }
    
    //Sets UIpad inactive and returns InteractionCube to the anchor
    public void UIButtonPress()
    {
        uiPad.SetActive(false);
        interactionCube.SetActive(false);
        anchorableBehaviour.isAttached = true;
        attachedToPinky = true;
    }

    //If InteractionCube attached, fingers extended and palm is up
    private void DisplayInteractionCube()
    {
        if (attachedToPinky)
        {
            interactionCube.SetActive(true);
        }
    }

    //Any other hand state change triggers this
    private void HideUI()
    {
        if (attachedToPinky)
        {
            interactionCube.SetActive(false);
        }
    }
}
