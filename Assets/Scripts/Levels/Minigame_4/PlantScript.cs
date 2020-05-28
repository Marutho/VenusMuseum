using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public GameObject plant1;
    public GameObject plant2;
    public GameObject plant3;
    public GameObject plant4;

    public int counterClicks;
    public int plantStatus;

    public int firstPlantClicks;
    public int secondPlantClicks;
    public int thirdPlantClicks;
    public int fourthPlantClicks;

    public bool winCondition;
    public bool plantBool;

    //Sounds
    public AudioClip tap;
    public AudioClip plantGrow1;
    public AudioClip plantGrow2;
    public AudioClip plantGrow3;
    public AudioClip plantGrow4;
    public AudioClip flower;
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.timeMultiplier = 0.50f;
        audio = GetComponent<AudioSource>();
        counterClicks = 0;
        plantBool = true;
        winCondition = false;
        plantStatus = 0;
        plant1.SetActive(false);
        plant2.SetActive(false);
        plant3.SetActive(false);
        plant4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (plantStatus)
        {
            case 0:
                if (counterClicks > firstPlantClicks)
                {
                    plantStatus = 1;
                    plant1.SetActive(true);
                    audio.PlayOneShot(plantGrow1, 0.4f);

                }
                break;

            case 1:
                if (counterClicks > secondPlantClicks)
                {
                    plantStatus = 2;
                    plant1.SetActive(false);
                    plant2.SetActive(true);
                    audio.PlayOneShot(plantGrow2, 0.8f);

                }
                break;

            case 2:
                if (counterClicks > thirdPlantClicks)
                {
                    plantStatus = 3;
                    plant2.SetActive(false);
                    plant3.SetActive(true);
                    audio.PlayOneShot(plantGrow3, 0.8f);
                }
                break;

            case 3:
                if (counterClicks >= fourthPlantClicks)
                {
                    plant3.SetActive(false);
                    plant4.SetActive(true);
                    if (plantBool == true)
                    {
                        audio.PlayOneShot(plantGrow4, 0.6f);
                        audio.PlayOneShot(flower, 0.8f);
                        plantBool = false;
                    }
                    gameObject.GetComponent<Collider2D>().enabled = false;
                    GameManager.instance.win = true;
                    GameManager.instance.lose = false;
                    GameManager.instance.timeMultiplier = 0.8f;
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
        audio.PlayOneShot(tap, 0.4f);     
        counterClicks++;
    }

}
