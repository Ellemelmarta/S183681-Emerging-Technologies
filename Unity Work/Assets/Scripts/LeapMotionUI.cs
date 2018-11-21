using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapMotionUI : MonoBehaviour {

    private bool palmIsUpUI;
    private bool fingersExtendedUI;

    private bool attachedToPinky = true;

    public GameObject uiPad;

    public GameObject interactionCube;


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
        DisplayUIPlus();
    }

    private void DisplayUIPlus()
    {
        uiPad.transform.position = Camera.main.transform.position + new Vector3(0, 0, 0.5f);
        uiPad.SetActive(true);
    }


    public void UIButtonPress()
    {
        print("great");
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
