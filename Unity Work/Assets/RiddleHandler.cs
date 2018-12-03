using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RiddleHandler : MonoBehaviour {

    private int answerNumber = 3;

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
            //wrong answers is computer 1 and 2
            case 1:
                computer1.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 2:
                computer2.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            //correct answer
            case 3:
                computer3.GetComponent<MeshRenderer>().material.color = Color.green;
                textForAnswer.text = "4) 4";
                break;
            default:
                break;
        }
    }
}
