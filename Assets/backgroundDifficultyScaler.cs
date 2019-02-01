using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backgroundDifficultyScaler : MonoBehaviour
{
    void Start()
    {
        shiftColour(1);
    }
    public void shiftColour(int difficulty)
    {
        if (difficulty == 1)
        {
            gameObject.GetComponent<Image>().color = new Color(Color.red.r, Color.red.g, Color.red.b,.18f);
        }
        else if (difficulty == 2)
        {
            gameObject.GetComponent<Image>().color = new Color(Color.green.r, Color.green.g, Color.green.b, .18f);
        }
        else if (difficulty == 3)
        {
            gameObject.GetComponent<Image>().color = new Color(Color.blue.r, Color.blue.g, Color.blue.b, .18f);
        }
    }
}
