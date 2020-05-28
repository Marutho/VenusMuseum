using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agustina : MonoBehaviour
{
    public GameObject AgustinaNormal;
    public GameObject AgustinaFire;

    //backgrounds
    public GameObject Soldiers;
    public GameObject NoSoldiers;

    //explosion
    public GameObject Explosion;

    //things of the timer
    public GameObject Timer;

    //booleans
    public bool winCondition;

    //Sounds
    public AudioClip hit;
    public AudioClip crowd;
    AudioSource audio;
    private bool soundCannon=true;
    private bool soundCrowd = true;

    //Manage difficulty
    public float minTimeSoldiersOff= 0.5f; 
    public float maxTimeSoldiersOff= 1.0f;
    public float minTimeSoldiersOn= 0.3f;
    public float maxTimeSoldiersOn = 0.75f;


    private float timeCount;
    private float soldiersTime;
    private bool soldiersAppeared;
    private bool soldiersAppearedFirstTime;
    private bool randomNumber;
    private float timeSoldiersOn;
    private float timeSoldiersOff;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0.0f;
        timeSoldiersOn = 0.0f;
        timeSoldiersOff = 0.0f;
        soldiersAppeared = false;
        soldiersAppearedFirstTime = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        if(Explosion.activeSelf == false)
        {
            if (timeCount > 0.3f && !soldiersAppearedFirstTime)
            {
                timeSoldiersOn = Random.Range(minTimeSoldiersOn, maxTimeSoldiersOn);
                soldiersAppearedFirstTime = true;
                soldiersAppeared = true;
            }

            if (soldiersAppearedFirstTime)
            {
                if (soldiersAppeared)
                {
                    switch (timeSoldiersOn > soldiersTime)
                    {
                        case true:
                            soldiersTime += dt;
                            break;

                        case false:
                            //Desactivacion de los soldados
                            Soldiers.SetActive(false);
                            timeSoldiersOff = Random.Range(minTimeSoldiersOff, maxTimeSoldiersOff);
                            soldiersAppeared = false;
                            soldiersTime = 0.0f;
                            break;

                    }
                }

                else if (!soldiersAppeared)
                {
                    switch (timeSoldiersOff > soldiersTime)
                    {
                        case true:
                            soldiersTime += dt;
                            break;

                        case false:
                            //Activacion de los soldados 
                            Soldiers.SetActive(true);
                            timeSoldiersOn = Random.Range(minTimeSoldiersOn, maxTimeSoldiersOn);
                            soldiersAppeared = true;
                            soldiersTime = 0.0f;
                            break;

                    }
                }
            }
        }
       


        if (AgustinaNormal.activeSelf == false)
        {
            if (soundCannon == true)
            {
                soundCannon = false;
                audio.PlayOneShot(hit, 0.8f);
            }

            if (Soldiers.activeSelf == true)
            {
                GameManager.instance.win = true;
                Explosion.SetActive(true);
                
                if(soundCrowd==true)
                {
                    soundCrowd = false;
                    audio.PlayOneShot(crowd, 0.3f);

                }
            
            }
            else
            {
                Explosion.SetActive(true);          
            }

         

        }

        

        timeCount += dt;
    }
}
