using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class DataController
{
    // Global RNG Seeder
    private static System.Random rng = new System.Random();

    // Grabs a filepath, then reads it and splits the CSV lines
    public static List<string[]> ParseQuestions(int difficulty){
        List<string[]> lvl_data = new List<string[]>();
        string readPath = string.Format("{0}/QuestionData/Level{1}Questions.csv", Application.dataPath, difficulty);
        string[] readText = File.ReadAllLines(readPath);
        for(int i = 1; i < readText.Length; ++i)
            lvl_data.Add(ParseCSV(readText[i]));

        return lvl_data;
    }

    // Splits a CSV row into a list of strings
    static string[] ParseCSV(string line){
        string[] elements = line.Split(',');
        return elements;
    }

    // RNG Machine with exclusion capabilities
    public static int RNG(int high, int low, int[] excluding){
        var exclude = new HashSet<int>();
        // Adds excluded ints to the hashset
        foreach(int num in excluding){
            exclude.Add(num);
        }
        // Loops and generates list of potential candidate ints to be rolled
        var range = Enumerable.Range(low, high).Where(i => !exclude.Contains(i));
        // Rolls an index for the new list of ints
        int index = rng.Next(low, high - exclude.Count);
        return range.ElementAt(index);
    }
}
