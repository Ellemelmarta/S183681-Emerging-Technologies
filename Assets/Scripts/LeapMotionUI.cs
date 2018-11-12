using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapMotionUI : MonoBehaviour {

    private bool palmIsUpUI;
    private bool fingersExtendedUI;

    public void OnAllFingers()
    {
        fingersExtendedUI = !fingersExtendedUI;

        if (palmIsUpUI && fingersExtendedUI)
        {
            DisplayUI();
        }
    }

    public void PalmDirectionChange()
    {
        palmIsUpUI = !palmIsUpUI;

        if (palmIsUpUI && fingersExtendedUI)
        {
            DisplayUI();
        }
    }

    private void DisplayUI()
    {
        print("the ui will display horray");
    }

}
