using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class menuButtons : MonoBehaviour
{
    //Allows us to define which scenes we want to load for the 1 player and 2 play buttons
    [SerializeField] string onePlayerScene;
    [SerializeField] string twoPlayerScene;
    //This is the list of buttons that the play() function affects for easy access
    public List<Button> playButtons = new List<Button>();
    //A bool to check and see if we've hit play or not
    bool playHit=false;

    //The function that is called when we hit Play/Back
    public void playBack()
    {
        //An int so we can keep track of our index through the foreach loop
        int index = 0;

        //If we haven't hit play (Play option)
        if(!playHit)
        {
            playHit = true;

            //Access the buttons in the list and change their text and functionality based on their index
            foreach(Button button in playButtons)
            {
                //Change the Play button to a back button
                if(index == 0)
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "Back";
                }
                //Change the Credits button to the 1 Player Button
                else if(index == 1)
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "1 Player";
                }
                //Change the Exit button to the 2 Player Button
                else if(index == 2)
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "2 Player";
                }

                index++;
            }
        }
        //If we have hit play (Back option)
        else
        {
            playHit = false;

            //Access the buttons in the list and change their text and functionality based on their index
            foreach(Button button in playButtons)
            {
                //Change the Back button to the Play button
                if(index == 0)
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "Play";
                }
                //Change the 1 Player button to the Credits Button
                else if(index == 1)
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "Credits";
                }
                //Change the 2 Player button to the Exit Button
                else if(index == 2)
                {
                    button.transform.GetChild(0).GetComponent<Text>().text = "Exit";
                }

                index++;
            }
        }
    }

    //The function that is called when the Credits/1 Player button is pressed
    public void credits1Player()
    {
        //If we haven't hit play (Credits option)
        if(!playHit)
        {
            loadScene("Credits");
        }
        //If we have hit play (1 Player Option)
        else
        {
            SceneManager.LoadScene(onePlayerScene);
        }
    }

    //The function that is called when the Exit/2 Player button is pressed
    public void exit2Player()
    {
        //If we haven't hit play (Exit option)
        if(!playHit)
        {
            Application.Quit();
        }
        //If we have hit play (2 Player Option)
        else
        {
            SceneManager.LoadScene(twoPlayerScene);
        }
    }

    //Used in Extras to return to menu. Must be a local (not static) function to be used by a button
    public void returnToMenu(string menuScene)
    {
        if(menuScene.Contains("Trivia"))
        {
            DestroyImmediate(GameObject.Find("Menu Music(Clone)"));
        }
        else if(menuScene.Contains("Results"))
        {
            createEscListner.musicNeeded = true;
        }
        loadScene(menuScene);
    }

    //A handy function that can be used anywhere to load a scene
    public static void loadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
