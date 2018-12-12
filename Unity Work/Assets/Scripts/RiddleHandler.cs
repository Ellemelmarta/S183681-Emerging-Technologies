using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RiddleHandler : MonoBehaviour {

    /*
     * 
     * This code handles the 3 buttons at the back of the room
     * that are used for solving the riddle on the screen
     * currently "What does UFO stand for?"
     * 
     */

    private GameObject computer3;
    private GameObject computer2;
    private GameObject computer1;

    public TextMeshPro textForAnswer;


    private void Start()
    {
        computer3 = GameObject.Find("console (2)");
        computer2 = GameObject.Find("console (3)");
        computer1 = GameObject.Find("console (1)");
    }


    public void OnRiddleButtonPressed(int riddleButtonNumber)
    {
        switch (riddleButtonNumber)
        {
            //Wrong answers are computer 1 and 2
            case 1:
                computer1.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 2:
                computer2.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            //Correct answer is computer 3
            case 3:
                computer3.GetComponent<MeshRenderer>().material.color = Color.green;
                textForAnswer.text = "IV) 1";
                break;
            default:
                break;
        }
    }
}
