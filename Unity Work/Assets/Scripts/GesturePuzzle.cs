using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GesturePuzzle : MonoBehaviour
{
    //All currently only for left hand

    private bool thumbIsUp;
    private bool thumbDirectionUp;
    private bool isInRange;

    private Material cubeColour;

    private void Start()
    {
        cubeColour =  gameObject.GetComponent<MeshRenderer>().material;
    }

    //is the thumb up not direction based
    public void OnThumbIsUpOrDown()
    {
        thumbIsUp = !thumbIsUp;

        //set from proximity script
        if (isInRange)
        {
            ThumbsUpCheck();
        }
    }

    //direction based thumb has to be pointing roughly 90 degrees on the y
    public void OnThumbDirectionUpOrDown()
    {
        thumbDirectionUp = !thumbDirectionUp;


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
        if (thumbIsUp && thumbDirectionUp)
        {
            //TODO: just for use as indication it worked at the moment please change
            cubeColour.color = Color.green;
        }
    }

}
