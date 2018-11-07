using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadManager : MonoBehaviour {

    public float timeUntilCodeReset;

    public TextMeshPro numberCodeText;

    public List<int> buttonNumberList;
    private int buttonNumberListMax = 5;

    private float timeSinceButtonPress = 0;

    private bool loopsRunning;
    private bool buttonPressed;


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

        //if the user is to mess up this will allow the list to be reset after short amount of time
        if (timeUntilCodeReset < timeSinceButtonPress)
        {
            loopsRunning = true;
            timeSinceButtonPress = 0;

            buttonNumberList.RemoveRange(0, buttonNumberList.Count);
            numberCodeText.text = "";
          
            loopsRunning = false;
        }
    }

    //Reusable function for all buttons in keypad
    public void ButtonPressed(int buttonNumber)
    {
        //making sure not to edit the list while items being removed.
        if (loopsRunning == false && buttonNumberList.Count < buttonNumberListMax)
        {
            buttonNumberList.Add(buttonNumber);
            numberCodeText.text = numberCodeText.text + buttonNumber;
        }

        buttonPressed = true;
        timeSinceButtonPress = 0;
    }


    public void ButtonStopPressed()
    {
        if (buttonPressed == true)
        {
            buttonPressed = false;
        }
    }
}
