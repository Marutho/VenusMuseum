using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conchi : MonoBehaviour
{
    //Conchis
    public GameObject conchiNormal;
    public GameObject conchiHit;

    //Sounds
    public AudioClip hit;
    AudioSource audio;


    //Timers
    private float timeCount;

    //booleans
    private bool canHit;
    private bool enter;

    // Start is called before the first frame update
    void Start()
    {
        enter = true;
        timeCount = 0.0f;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        if(timeCount>0.45)
        {
            conchiNormal.SetActive(true);
            conchiHit.SetActive(false);
            timeCount = 0.0f;
        }

        if(timeCount>0.2)
        {
            canHit = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            conchiNormal.SetActive(false);
            conchiHit.SetActive(true);
            canHit = true;
        }

        if(conchiHit.activeSelf==true)
        {
            timeCount += dt;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {      
        if(canHit==true && collision.CompareTag("TennisBall"))
        {
           // audio.PlayOneShot(hit, 0.8f);
            collision.GetComponent<Ball>().direction = 1;
            if(collision.GetComponent<Ball>().speed < 30)
            {
                collision.GetComponent<Ball>().speed += 1.3f;
            }

            if(enter)
            {
                audio.PlayOneShot(hit, 0.8f);
                enter = false;
            }
              
        }
            
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enter = true;
    }


}
