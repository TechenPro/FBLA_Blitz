using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : StateMachine
{
    #region Static Properties
    // These allow the GameController to easily be accessed by any other GameObject
    public static GameController Instance {
        get{
            return instance;
        }
    }

    static GameController instance;
    #endregion

    // Global Time Controls
    public Timer gameTimer;
    public float gameLength;

    //PlayerList
    public PlayerController player1;
    public PlayerController player2;

    /* List of questions with structure:
        [
            DifficultyLvl 1 [
                question[...]
                question[...]
                question[...]
                ...
            ]

            DifficultyLvl 2 [
                question[...]
                question[...]
                question[...]
                ...
            ]

            ...

        ] */
    public List<List<string[]>> questions = new List<List<string[]>>();

    // Sets up neccessary objects
    void Start(){
        instance = gameObject.GetComponent<GameController>();
        gameTimer.Init(gameLength, endGame);
        ChangeState<InitGameState>();
    }

    // Unused in current build
    // public void PauseGame(){
    //     ChangeState<PausedGameState>();
    // }

    // public void PauseTimers(){
    //     gameTimer.StopTimer();
    //     player1.Pause();
    // }

    // public void ResumeTimers(){
    //     gameTimer.ResumeTimer();
    //     player1.Resume();
    // }

    public void LoadGameData(){
        // Parses lvl 1-3 Questions and puts them into the questions list
        for(int i=0; i<3; i++){
            List<string[]> lvl_data = DataController.ParseQuestions(i+1);
            questions.Add(lvl_data);
        }

    }

    // Sends a new question to the player object
    public string[] ServeQuestion(PlayerController p){
        int index = DataController.RNG(questions[p.LVL].Count, 0, (p.LVL == 2 ? new int[0] : p.answeredQuestions.ToArray()));
        // Prevents repeating the same question
        p.answeredQuestions.Add(index);
        return questions[p.LVL][index];
    }

    // End game callback function of the GameTimer
    public void endGame()
    {
        int p2score = (player2 ? player2.score : 0);
        gameInfo.setScores(player1.score, p2score);
        Debug.Log("Ending Game");
        menuButtons.loadScene("Results Screen");
    }

}
