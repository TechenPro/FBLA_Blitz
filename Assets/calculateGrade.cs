using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculateGrade : MonoBehaviour
{
    [SerializeField] int aRank;
    [SerializeField] int fRank;
    [SerializeField] string aDesc;
    [SerializeField] string fDesc;
    [SerializeField] string oneWon;
    [SerializeField] string twoWon;
    [SerializeField] string draw;
    [SerializeField] Text description;
    int player1Score;
    int player2Score;

    // Start is called before the first frame update
    void Start()
    {
        player1Score = gameInfo.player1Score;
        player2Score = gameInfo.player2Score;
        if(player2Score == 0)
        {
            calculatePlayer1Score();
        }
        else
        {
            compareScores();
        }
        gameInfo.resetScores();
    }
    public void calculatePlayer1Score()
    {
        if(player1Score >= aRank)
        {
            changeText("P");
            changeDescription(aDesc);
        }
        else if(player1Score < aRank && player1Score >= fRank)
        {
            changeText("F");
            changeDescription(fDesc);
        }
    }

    public void compareScores()
    {
        if (player1Score > player2Score)
        {
            changeText("1");
            changeDescription(oneWon);
        }
        else if (player1Score < player2Score)
        {
            changeText("2");
            changeDescription(twoWon);
        }
        else if (player1Score == player2Score)
        {
            changeText("?");
            changeDescription(draw);
        }
    }

    void changeText(string newText)
    {
        gameObject.GetComponent<Text>().text = newText;
    }

    void changeDescription(string newDesc)
    {
        description.text = newDesc;
    }
}
