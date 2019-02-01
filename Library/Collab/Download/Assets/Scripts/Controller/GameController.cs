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

    void Start(){
        instance = gameObject.GetComponent<GameController>();
        gameTimer.Init(gameLength, endGame);
        // Debug.Log("Init State");
        ChangeState<InitGameState>();
    }

    public void PauseGame(){
        ChangeState<PausedGameState>();
    }

    public void PauseTimers(){
        gameTimer.StopTimer();
        player1.Pause();
    }

    public void ResumeTimers(){
        gameTimer.ResumeTimer();
        player1.Resume();
    }

    public void LoadGameData(){
        for(int i=0; i<3; i++){
            List<string[]> lvl_data = DataController.ParseQuestions(i+1);
            questions.Add(lvl_data);
        }

    }

    public string[] ServeQuestion(PlayerController p){
        int index = DataController.RNG(questions[p.LVL].Count, 0, p.answeredQuestions.ToArray());
// ############################################# UNCOMMENT THE FOLLOWING LINE ONCE YOU HAVE ENOUGH QUESTIONS (At least 15 in lvl 1 & 2, with a lot in lvl 3)!!!!!!!!!!!!###################################################
        p.answeredQuestions.Add(index);
        return questions[p.LVL][index];
    }

    public void endGame()
    {
        int p2score = (player2 ? player2.score : 0);
        gameInfo.setScores(player1.score, p2score);
        Debug.Log("Ending Game");
        menuButtons.loadScene("Results Screen");
    }

}
