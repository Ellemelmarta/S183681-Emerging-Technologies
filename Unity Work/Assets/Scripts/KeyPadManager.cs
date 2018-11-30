using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadManager : MonoBehaviour {

    //Public due to use in TMPro
    public List<int> buttonNumberList;
    
    //TODO: may be better to hardcode these in the future
    public List<int> buttonNumberListAnswer;
    public float timeUntilCodeReset;
    public TextMeshPro numberCodeText;

    private int buttonNumberListMax = 5;

    private float timeSinceButtonPress = 0.0f;

    private bool loopsRunning;
    private bool buttonPressed;

    public GameObject finalDoor;


    private void Start()
    {
        buttonPressed = false;
    }

    private void Update()
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
            numberCodeText.color = Color.white;
            loopsRunning = false;
        }
    }

    //Reusable function for all buttons in keypad
    public void NumberButtonPressed(int buttonNumber)
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
        if (buttonNumberList.Count == buttonNumberListAnswer.Count)
        {
            CodeNumberComparison();
        }

        buttonPressed = false;
    }


    //only runs when the list is full and the user releases the button
    //on release of 5th number or any further releases
    private bool CodeNumberComparison()
    {
        int correctAnswerCount = 0;

        //compares the count of correct comparisons from the 2 lists (in order as well)
        for (int currentNum = 0; currentNum < buttonNumberList.Count; currentNum++)
        {
            if (buttonNumberList[currentNum] == buttonNumberListAnswer[currentNum])
            {
                correctAnswerCount ++;
            }
        }
        
        if (correctAnswerCount == buttonNumberListAnswer.Count)
        {
            numberCodeText.color = Color.green;
            finalDoor.GetComponent<Animator>().Play("glass_door_open", 0);
            return true;
        }

        else
        {
            numberCodeText.color = Color.red;
            return false;
        }
    }

}
