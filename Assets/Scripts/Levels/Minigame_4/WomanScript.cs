using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanScript : MonoBehaviour
{
    public GameObject woman1;
    public GameObject woman2;
    public GameObject woman3;

    public int counterClicks;
    public int plantStatus;

    public int firstPlantClicks;
    public int secondPlantClicks;
    public int thirdPlantClicks;

    public bool winCondition;
    public bool womanBool;

    //Sounds
    public AudioClip tap;
    public AudioClip woman;
    public AudioClip womanGrow;
    public AudioClip womanGrow2;
    public AudioClip womanGrow3;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.timeMultiplier = 0.40f;
        womanBool = true;
        audio = GetComponent<AudioSource>();
        counterClicks = 0;
        winCondition = false;
        plantStatus = 0;
        woman1.SetActive(false);
        woman2.SetActive(false);
        woman3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager.instance.timeMultiplier);

        switch (plantStatus)
        {
            case 0:
                if (counterClicks > firstPlantClicks)
                {
                    plantStatus = 1;
                    woman1.SetActive(true);
                    audio.PlayOneShot(womanGrow, 0.4f);
                }
                break;

            case 1:
                if (counterClicks > secondPlantClicks)
                {
                    plantStatus = 2;
                    woman1.SetActive(false);
                    woman2.SetActive(true);
                    audio.PlayOneShot(womanGrow2, 0.4f);
                }
                break;

            case 2:
                if (counterClicks >= thirdPlantClicks)
                {

                    
                    woman2.SetActive(false);
                    woman3.SetActive(true);
                    if (womanBool==true)
                    {
                        audio.PlayOneShot(womanGrow3, 0.8f);
                        audio.PlayOneShot(woman, 1.0f);
                        womanBool = false;   
                    }
                    gameObject.GetComponent<Collider2D>().enabled = false;
                    GameManager.instance.win = true;
                    GameManager.instance.lose = false;
                    GameManager.instance.timeMultiplier = 1.0f;
                }
                break;

            default:
                break;
        }

        if (GameManager.instance.lose == true)
        {
            GameManager.instance.timeMultiplier = 1.0f;
        }

    }

    private void OnMouseDown()
    {
        Debug.Log(counterClicks);
        audio.PlayOneShot(tap, 0.4f);
        counterClicks++;
    }

}
