using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisEnemy : MonoBehaviour
{
    //Conchis
    public GameObject enemyNormal;
    public GameObject enemyHit;

    //Timers
    private float timeCount;

    //Sounds
    public AudioClip hit;
    AudioSource audio;

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

        if (timeCount > 0.45)
        {
            enemyNormal.SetActive(true);
            enemyHit.SetActive(false);
            timeCount = 0.0f;
        }

        if (enemyHit.activeSelf == true)
        {
            timeCount += dt;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TennisBall"))
        {           
            enemyNormal.SetActive(false);
            enemyHit.SetActive(true);
            collision.GetComponent<Ball>().direction = -1;
            if (collision.GetComponent<Ball>().speed < 27)
            {
                collision.GetComponent<Ball>().speed += 1.3f;
            }

                       
        }
        if (enter)
        {
            enter = false;
            audio.PlayOneShot(hit, 0.8f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enter = true;
    }

}
