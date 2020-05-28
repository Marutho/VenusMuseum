using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCheck : MonoBehaviour
{

    public GameObject[] hearts;
    public Texture h1;
    public Texture h2;

    private float time;

    void Start()
    {

        int iter = 0;

        for(iter = 0; iter < GameManager.instance.totalLives; iter++)
        {
            hearts[iter].SetActive(true);
        }

        for(;iter < 4; iter++)
        {
            hearts[iter].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        
        if(GameManager.instance.totalLives <= 0)
        {
            GameManager.instance.exitGame = true;
        }

        if((int)time%2 == 0)
        {
            foreach(GameObject go in hearts)
            {
                go.GetComponent<RawImage>().texture = h1;
            }
        }

        else if((int)time%2 != 0)
        {
            foreach (GameObject go in hearts)
            {
                go.GetComponent<RawImage>().texture = h2;
            }
        }


        time += dt * 5.0f;
    }
}
