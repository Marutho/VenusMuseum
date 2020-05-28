using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour
{
    
    //Sounds
    /*public AudioClip clock;
    AudioSource audio;*/

    //Barras
    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public GameObject bar4;
    public GameObject final;

    private float timePassed;
    private int barStatus;
    

    void Start()
    {
        barStatus = 0;
        timePassed = 0;

    }

    private void Update()
    {
        float dt = Time.deltaTime;

        switch (barStatus)
        {
            case 0:
                if (timePassed > 1.0f)
                {
                    barStatus = 1;
                    bar1.SetActive(false);
                    bar2.SetActive(true);
                }
                break;

            case 1:
                if (timePassed > 2.0f)
                {
                    barStatus = 2;
                    bar2.SetActive(false);
                    bar3.SetActive(true);
                }
                break;

            case 2:
                if (timePassed > 3.0f)
                {
                    barStatus = 3;
                    bar3.SetActive(false);
                    bar4.SetActive(true);
                }
                break;

            case 3:
                if (timePassed > 4.0f)
                {
                    barStatus = 4;
                    bar4.SetActive(false);
                    final.SetActive(true);
                }
                break;

            case 4:
                if (timePassed > 5.0f)
                {
                    barStatus = 5;
                    final.SetActive(false);
                    if (!GameManager.instance.win)
                    {
                        GameManager.instance.lose = true;
                    }

                    if (GameManager.instance.lose)
                        GameManager.instance.totalLives--;

                    EyeAnimation_Manager eye = GameObject.FindGameObjectWithTag("Eyes").GetComponent<EyeAnimation_Manager>();
                    eye.eState = EyeAnimation_Manager.EyeState.Closing;
                    GameManager.instance.backToPainting = true;
                }
                break;

            default:
                break;
        }

        timePassed += dt * GameManager.instance.timeMultiplier * GameManager.instance.difficulty;
    }
   
}

