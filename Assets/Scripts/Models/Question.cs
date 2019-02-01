using System;
using System.Collections;

[System.Serializable]
public struct Question
{
    // Custom Question data structure. Has the following properties
    public string q;
    public string a1;
    public string a2;
    public string a3;
    public string a4;
    public int ca;

    public Question(string[] q_data):this(){
        Initialize(q_data);
    }

    private void Initialize(string[] q_data){
        this.q = q_data[0];
        this.a1 = q_data[1];
        this.a2 = q_data[2];
        this.a3 = q_data[3];
        this.a4 = q_data[4];
        if(Int32.TryParse(q_data[5], out this.ca)) return;
        //Exception Handling Just in Case
        else this.ca = 1;

    }

    public void LoadData(string[] q_data){
        if(q_data.Length == 6)
            this.Initialize(q_data);
    }

    public override string ToString(){
        return string.Format("({0},{1},{2},{3},{4},{5})", q, a1, a2, a3, a4, ca);
    }
}
