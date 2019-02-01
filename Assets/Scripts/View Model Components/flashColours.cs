using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashColours : MonoBehaviour
{
    //This allows us to access the colours we want the lights to potentially be from the editor
    public List<Color> potentialColours = new List<Color>();

    //This lets us change the rate at which the colours flash in the editor
    public float flashRate;

    // Start is called before the first frame update
    void Start()
    {
        //Randomizes the lights and tells it to do so however often we tell it to in the editor
        InvokeRepeating("randomizeLights",0,flashRate);
    }

    //This method goes through and changes the colour of each of the lights randomly
    void randomizeLights()
    {
        int randomIndex;

        //Run through each child in our transform, which is, in this case, a light
        foreach(Transform light in transform)
        {
            //Get a random number to access a random index from the list
            randomIndex = Random.Range(0,potentialColours.Count);

            //Change the colour based on the random index position
            light.GetComponent<MeshRenderer>().material.color = potentialColours[randomIndex];
        }
    }
}
