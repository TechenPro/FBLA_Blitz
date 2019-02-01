using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEscListner : MonoBehaviour
{
    //Lets us check to see if we've already created the listener, as the scene the spawner may be in will be loaded multiple times
    public static bool created=false;
    //Lets us check if we need to create another music player
    public static bool musicNeeded=true;

    // Start is called before the first frame update
    void Start()
    {
        //Creates an escape listener (but only once)
        if(!created)
        {
            Object listener = Instantiate(Resources.Load("EscListener"),Vector3.zero,Quaternion.identity);
            DontDestroyOnLoad(listener);
            created = true;
        }
        if(musicNeeded)
        {
            Object musicPlayer = Instantiate(Resources.Load("Menu Music"), Vector3.zero, Quaternion.identity);
            DontDestroyOnLoad(musicPlayer);
            musicNeeded = false;
        }
    }
}
