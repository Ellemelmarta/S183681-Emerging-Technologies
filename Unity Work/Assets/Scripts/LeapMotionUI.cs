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
        DisplayUIPlus();
    }

    public void OnDetachedFromHand()
    {
        attachedToPinky = false;
        DisplayUIPlus();
    }


    //clean up this name??
    private void DisplayUIPlus()
    {
        uiPad.transform.position = Camera.main.transform.position + new Vector3(0, 0, 0.5f);
        if (attachedToPinky == true)
        {
            uiPad.SetActive(false);
        }
        else
        {
            uiPad.SetActive(true);
        }
    }

    // doesnt work
    public void UIButtonPress()
    {
        uiPad.SetActive(false);
        interactionCube.SetActive(false);
        anchorableBehaviour.isAttached = true;
        attachedToPinky = true;
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
