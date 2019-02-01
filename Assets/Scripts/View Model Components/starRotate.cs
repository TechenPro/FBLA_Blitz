using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starRotate : MonoBehaviour
{
    //A handy bool that lets us change which direction in which we rotate
    public bool moveLeft;

    // Update is called once per frame
    void Update()
    {
        //Rotate either left or right to give a nice aesthetic look
        if(moveLeft)
        {
            transform.RotateAround(new Vector3(0, 0, 1), .025f);
        }
        else
        {
            transform.RotateAround(new Vector3(0, 0, 1), -.025f);
        }       
    }
}
