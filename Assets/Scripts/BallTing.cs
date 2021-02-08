using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class BallTing : MonoBehaviour
{
    bool validateTarget1 = false;
    bool validateTarget2 = false;
    float time;
    public static int totalScore = 10000000;
    public GameObject scoreUI;
    public GameObject screenTextUI;
    public Text scoreDisplay;
    public GameObject highScoreUI;
    public GameObject ButtonUI;
    public GameObject InputFieldUI;
    public GameObject inputField;
    public int[] highScore = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public string[] highScoreNames = new string[10];
    public Text highScoreText1;
    public Text highScoreText2;
    public Text highScoreText3;
    public Text highScoreText4;
    public Text highScoreText5;
    public Text highScoreText6;
    public Text highScoreText7;
    public Text highScoreText8;
    public Text highScoreText9;
    public Text highScoreText10;
    string pathToScores;
    string pathToNames;
    public string userName;

    List<String> highScoreString;
    List<String> highScoreStringNames;

    


    // Start is called before the first frame update
    void Start()
    {
        pathToScores = Application.dataPath + "HighScore.txt";
        pathToNames = Application.dataPath + "HighScoreNames.txt";

        highScoreString = new List<string>();
        highScoreStringNames = new List<string>();

        if (File.Exists(pathToNames) && File.Exists(pathToScores))
        {
            highScore = Array.ConvertAll(File.ReadAllLines(pathToScores), int.Parse);
            highScoreNames = File.ReadAllLines(pathToNames);
        }

        else
        {
            using (FileStream fs = File.Create(pathToScores))
            {

            }

            using (FileStream fs = File.Create(pathToNames))
            {

            }

            for (int i = 0; i < 10; i++)
            {
                highScoreString.Add("0");
                highScoreStringNames.Add("");
            }

            File.WriteAllLines(pathToScores, highScoreString);
            File.WriteAllLines(pathToNames, highScoreStringNames);

            highScoreString.Clear();
            highScoreStringNames.Clear();

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug, ska bort
        if (Input.GetKeyDown(KeyCode.B) && !CubeTing.isScoreActive) //Debug, ska bort
        {
            validateTarget1 = true;
            validateTarget2 = true;
        }

        if (validateTarget1 && validateTarget2)
        {
            Win();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target1")
        {
            validateTarget1 = true;
        }

        if (collision.gameObject.tag == "Target2")
        {
            validateTarget2 = true;
        } 
    }

    private void Win()
    {
        CubeTing.isScoreActive = true;
        validateTarget1 = false;
        screenTextUI.SetActive(false);
        time = Time.timeSinceLevelLoad;
        totalScore /= Convert.ToInt32((time / 2) * OnScreenText.bounce * 2);
        scoreDisplay.text = "Congratulations! \nYour Score: " + totalScore.ToString();        
        scoreUI.SetActive(true);
        StartCoroutine(Wait(1));
    }

    public static IEnumerator Wait(int temp)
    {
        yield return new WaitForSeconds(temp);
        Time.timeScale = 0;
    }

    public void HighScore()
    {

        userName = inputField.GetComponent<Text>().text;


        for (int i = 0; i < highScore.Length; i++)
        {
            if (highScore[i] == 0)
            {
                highScore[i] = totalScore;
                highScoreNames[i] = userName;
                break;
            }
            
            if (highScore[i] < totalScore)
            {
                for (int j = highScore.Length - 1; j > i; j--)
                {
                    highScore[j] = highScore[j - 1];
                }

                for (int j = highScore.Length - 1; j > i; j--)
                {
                    highScoreNames[j] = highScoreNames[j - 1];
                }


                highScore[i] = totalScore;
                highScoreNames[i] = userName;
                break;
            }
        }

        for (int i = 0; i < highScore.Length; i++)
        {
            highScoreString.Add(highScore[i].ToString());
            highScoreStringNames.Add(highScoreNames[i]);
        }

        File.WriteAllLines(pathToScores, highScoreString);
        File.WriteAllLines(pathToNames, highScoreStringNames);

        for (int i = 0; i < highScore.Length; i++)
        {
            switch (i)
            {
                case 0:
                    highScoreText1.text = "1. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 1:
                    highScoreText2.text = "2. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 2:
                    highScoreText3.text = "3. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 3:
                    highScoreText4.text = "4. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 4:
                    highScoreText5.text = "5. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 5:
                    highScoreText6.text = "6. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 6:
                    highScoreText7.text = "7. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 7:
                    highScoreText8.text = "8. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 8:
                    highScoreText9.text = "9. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
                case 9:
                    highScoreText10.text = "10. " + highScore[i].ToString() + " " + highScoreNames[i];
                    break;
            }
        }

        highScoreUI.SetActive(true);
        ButtonUI.SetActive(false);
        InputFieldUI.SetActive(false);
        CubeTing.isScoreActive = false;
    }
}
