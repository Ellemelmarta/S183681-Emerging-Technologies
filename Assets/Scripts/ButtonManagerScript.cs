using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagerScript : MonoBehaviour {

    public float timeUntilCodeReset;
    private float timeSinceButtonPress = 0;

    private bool loopsRunning;
    private bool buttonPressed;

    public int button1Number;
    public int button2Number;

    public List<int> buttonNumberList;

    private void Start()
    {
        buttonPressed = false;
    }


    private void FixedUpdate()
    {
        if (buttonPressed != true)
        {
            timeSinceButtonPress += Time.deltaTime;
        }

        //if the user is to mess up this will allow the code to be reset after short amount of time
        if (timeUntilCodeReset < timeSinceButtonPress)
        {
            loopsRunning = true;
            timeSinceButtonPress = 0;

            buttonNumberList.RemoveRange(0, buttonNumberList.Count);
          
            loopsRunning = false;
        }
    }

    //Try find a way to make this more efficent instead of a different function for
    //each button as all i do is change the number added to the list...
    public void Button1IsPressed()
    {
        if (buttonPressed == false)
        {
            //making sure not to edit the list while items being removed.
            if (loopsRunning == false)
            {
                buttonNumberList.Add(button1Number);
            }
            buttonPressed = true;
            timeSinceButtonPress = 0;
        }
    }


    public void Button2IsPressed()
    {
        if (buttonPressed == false)
        {
            if (loopsRunning == false)
            {
                buttonNumberList.Add(button2Number);
            }
            buttonPressed = true;
            timeSinceButtonPress = 0;
        }
    }


    public void ButtonStopPressed()
    {
        if (buttonPressed == true)
        {
            buttonPressed = false;
        }
    }
}
