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
        anchorableBehaviour = interactionCube.GetComponent<AnchorableBehaviour>();
    }


    //all fingers extended for UIManager
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

    //palm up for UIManager
    public void PalmDirectionChange()
    {
        palmIsUpUI = !palmIsUpUI;

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
        //uipad follows the front of the camera as using camera position doesnt work.
        if (attachedToPinky == true)
        {
            uiPad.SetActive(false);
        }
        else
        {
            uiPad.SetActive(true);
        }
    }
    
    //removes the uipad and returns the interaction cube to the users hand for another use
    public void UIButtonPress()
    {
        uiPad.SetActive(false);
        interactionCube.SetActive(false);
        anchorableBehaviour.isAttached = true;
        attachedToPinky = true;
    }

    //if attached, fingers extended and palm is up
    private void DisplayInteractionCube()
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
