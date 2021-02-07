using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ScoreText : MonoBehaviour
{
    private float startTime;
    private float currentTime;
    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - startTime;

        string minutes = ((int) currentTime / 60).ToString("00");
        string seconds = ((int)currentTime % 60).ToString("00");

        timer.text = $"{minutes}:{seconds}";
    }
}
