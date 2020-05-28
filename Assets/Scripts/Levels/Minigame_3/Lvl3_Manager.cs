using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3_Manager : MonoBehaviour
{
    public GameObject vaso1;
    public GameObject vaso2;

    public GameObject vasoLleno1;
    public GameObject vasoLleno2;

    public GameObject vasoLlenoGUAY1;
    public GameObject vasoLlenoGUAY2;

    void Awake()
    {
        GameManager.instance.timeMultiplier = 0.60f;
    }

    void Update()
    {
        if(vaso1.GetComponent<Lab_WinCondition>().winCondition==true && vaso2.GetComponent<Lab_WinCondition>().winCondition == true)
        {
            vasoLlenoGUAY1.SetActive(true);
            vasoLlenoGUAY2.SetActive(true);
            GameManager.instance.win = true;
            GameManager.instance.timeMultiplier = 1.0f;
        }

        if(GameManager.instance.lose == true)
        {
            GameManager.instance.timeMultiplier = 1.0f;
        }
    }
}
