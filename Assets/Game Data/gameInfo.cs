using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInfo : MonoBehaviour
{
    //Stores Player 1 and 2's scores
    public static int player1Score;
    public static int player2Score;

    public static void setScores(int oneScore, int twoScore = 0)
    {
        player1Score = oneScore;
        player2Score = twoScore;
    }

    public static void resetScores()
    {
        player1Score = 0;
        player2Score = 0;
        createEscListner.musicNeeded = true;
    }
}
