using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadManager : MonoBehaviour {

    //Public due to use in TMPro text
    public List<int> buttonNumberList;
    
    //4,3,0,1,4
    public List<int> buttonNumberListAnswer;

    public float timeUntilCodeReset;
    public TextMeshPro numberCodeText;

    private int buttonNumberListMax = 5;

    private float timeSinceButtonPress = 0.0f;

    private bool loopsRunning;
    private bool buttonNumberPressed;

    public GameObject finalDoor;


    private void Start()
    {
        buttonNumberPressed = false;
    }


    private void Update()
    {
        //Makes sure the code being entered doesnt reset if player still inputing numbers
        if (buttonNumberPressed != true)
        {
            timeSinceButtonPress += Time.deltaTime;
        }

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

    //For all buttons in keypad
    public void NumberButtonPressed(int buttonNumber)
    {
        //Making sure not to edit the list while items being removed.
        if (loopsRunning == false && buttonNumberList.Count < buttonNumberListMax)
        {
            buttonNumberList.Add(buttonNumber);
            numberCodeText.text = numberCodeText.text + buttonNumber;
        }

        buttonNumberPressed = true;
        timeSinceButtonPress = 0;
    }


    public void ButtonStopPressed()
    {
        if (buttonNumberList.Count == buttonNumberListAnswer.Count)
        {
            CodeNumberComparison();
        }

        buttonNumberPressed = false;
    }


    //Only runs when the list is full and the user releases the button
    private bool CodeNumberComparison()
    {
        int correctAnswerCount = 0;

        //Compares the count of correct comparisons from the 2 lists (in order as well)
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
