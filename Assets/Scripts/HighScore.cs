using System;
using UnityEngine;

public class HighScore
{
    private string _name;
    private int _score;

    public HighScore()
    {
        Name = "Unknown";

        Score = 0;
    }

    public string Name
    {
        get => _name;

        set { _name = value; }
    }

    public int Score
    {
        get => _score;

        set { _score = value; }
    }
}
