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


    /// <summary>
    /// 
    /// TODO: 
    /// 
    /// 1)  Allow the list of ints to compare to the "keypad answer" which will also be a list of ints and this will just
    ///     be the correct answer to the keypad, either can do this by adding another button for the comparison or making it on
    ///     a gesture from the leap motion.
    ///     
    /// 2)  Make the colour of a block changed to show if you got it right or not, doesnt matter what block for now as its just
    ///     for a visual representation of the answers bool wrong or right.
    /// 
    /// </summary>


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
            print(true);
            return true;
        }

        else
        {
            print(false);
            return false;
        }
    }

}
