using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestureBlock : MonoBehaviour
{
    //All only for left hand
    private bool fingerExtensionIsCorrect;
    private bool fingerDirectionCorrect;
    private bool isInRange;

    public TextMeshPro answerText;
    private static int gestureBlocksCorrect;

    private Material cubeColour;

    private void Start()
    {
        cubeColour =  gameObject.GetComponent<MeshRenderer>().material;
    }

    //is the thumb up not direction based
    public void OnThumbIsUpOrDown()
    {
        fingerExtensionIsCorrect = !fingerExtensionIsCorrect;

        //set from proximity script
        if (isInRange)
        {
            ThumbsUpCheck();
        }
    }

    //direction based thumb has to be pointing roughly 90 degrees on the y
    public void OnThumbDirectionUpOrDown()
    {
        fingerDirectionCorrect = !fingerDirectionCorrect;


        if (isInRange)
        {
            ThumbsUpCheck();
        }
    }


    public void PlayerInRangeOfBlock()
    {
        isInRange = !isInRange;
    }

    //checks for our specific gesture currently a thumbs up
    private void ThumbsUpCheck()
    {
        if (fingerExtensionIsCorrect && fingerDirectionCorrect)
        {
            cubeColour.color = Color.green;
            gestureBlocksCorrect += 1;

            if (gestureBlocksCorrect == 3)
            {
                answerText.alpha = 255;
            }
        }

        
    }

}
