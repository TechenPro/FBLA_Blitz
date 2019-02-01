using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : StateMachine
{
    // Times each question
    public Timer questionTimer;

    // Game Controlling Values
    public int LVL {
        get{return lvl;}
    }
    private int lvl=0;
    int deltaScore=0;
    public int score=50;
    bool blitzActivated = false;
    // Serialized for easy game balancing
    [SerializeField] float pointGainRate = 1.5f;
    [SerializeField] int penaltyPoints = 50;
    [SerializeField] int difficultyThreshold = 1000;

    // Child Game Objects
    public BlitzMeter blitzMeter;
    public Text questionText;
    public Text a1Text;
    public Text a2Text;
    public Text a3Text;
    public Text a4Text;
    public Text timeDisplay;
    [SerializeField] Image background;

    // Question data
    static string[] default_q = new string[] {"Hit a Button to Start...", "Start", "Start", "Start", "Start", "0"};
    private Question playerQuestion = new Question(default_q);
    public List<int> answeredQuestions = new List<int>();
    int questionCount = 0;


    #region Game States
    public void Pause(){
        questionTimer.StopTimer();
    }

    public void Resume(){
        ChangeState<NormalPlayState>();
        questionTimer.ResumeTimer();
    }
    #endregion

    void Start(){
        background.GetComponent<backgroundDifficultyScaler>().shiftColour(lvl + 1);
        questionTimer.Init(10f, NewPlayerTurn);
        blitzMeter.blitzTimer.Init(20f, ExitBlitz);
        LoadQuestion(playerQuestion);
        ChangeState<NormalPlayState>();
    }

    #region Main Game Controlling Functions
    /*Needed Functions:
        Blitz Meter Add
        Blitz Extensions(Shorter Time Limit, Double Points, BG Color Change)*/
    public void NewPlayerTurn(){
        LoadQuestion();
        ResetTimer();
    }

    // Fetches a question from the game controller
    public void LoadQuestion(){
        playerQuestion.LoadData(GameController.Instance.ServeQuestion(this));

        // Logic to assign values to different text fields
        questionText.text = playerQuestion.q;
        a1Text.text = playerQuestion.a1;
        a2Text.text = playerQuestion.a2;
        a3Text.text = playerQuestion.a3;
        a4Text.text = playerQuestion.a4;

        // Difficulty Swapping
        questionCount += 1;
        Debug.Log(questionCount);
        if(questionCount > 14){
            Debug.Log(lvl);
            if(lvl < 2)
            {
                lvl++;
                background.GetComponent<backgroundDifficultyScaler>().shiftColour(lvl+1);
                deltaScore = 0;
                questionCount = 0;
            }
        }
    }
    public void LoadQuestion(Question q){

        questionText.text = q.q;
        a1Text.text = q.a1;
        a2Text.text = q.a2;
        a3Text.text = q.a3;
        a4Text.text = q.a4;
    }

    private void ResetTimer(){
        float time = (blitzActivated ? 5f : 10f);
        questionTimer.StartTimer(10f);
    }
    #endregion

    // Button Listener
    public void getButtonNumber(int buttonNumber){
        ChooseAnswer(buttonNumber);
    }

    public void ChooseAnswer(int choice){
        AwardPoints(choice);
        NewPlayerTurn();
    }

    // Scoring Algorithm
    public void AwardPoints(int answerChosen){
        int points;

        if(playerQuestion.ca == answerChosen)
            points = Mathf.CeilToInt((100*Mathf.Pow((lvl + 1),pointGainRate)/*+timeBonus*/));
        else
            points = -penaltyPoints;

        if(blitzActivated) points *= 2;

        deltaScore += points;
        score += points;

        // if(deltaScore > difficultyThreshold && lvl < 2){
        //     lvl++;
        //     deltaScore = 0;
        // }
        if(!blitzActivated) blitzMeter.AddMeter(10);
    }

    // Blitz Mode Functions
    public void EnterBlitz(){
        blitzActivated = true;
        blitzMeter.blitzTimer.StartTimer(20f);
        blitzMeter.transform.GetChild(1).gameObject.SetActive(true);
        blitzMeter.active = true;
        blitzMeter.BeginInvoke();
        Camera.main.GetComponent<AudioSource>().Pause();
        GameObject.Find("Global Canvas").GetComponent<AudioSource>().Play();
    }

    public void ExitBlitz(){
        blitzMeter.active = false;
        blitzActivated = false;
        blitzMeter.StopInvoke();
        blitzMeter.transform.GetChild(1).gameObject.SetActive(false);
        Camera.main.GetComponent<AudioSource>().Play();
    }




    void Update(){
        timeDisplay.text = questionTimer.DisplayTime.ToString();
    }

}
