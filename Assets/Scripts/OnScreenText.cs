using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class OnScreenText : MonoBehaviour
{
    public Text timeDisplay;

    public static int bounce = 0;

    // Start is called before the first frame update
    void Start()
    {
        bounce = 0;
        timeDisplay = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        timeDisplay.text = bounce.ToString();

    }
}


//Ta reda på om tiden nollställs. Reversera den visade tiden istället för att använda en egen funktion när poängen räknas ut.