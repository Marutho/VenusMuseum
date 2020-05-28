using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    public Sprite[] textures;
    public Vector3 targetPosition;
    
    private float time;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        if (GameManager.instance.exitGame)
        {
            if (transform.position.y > targetPosition.y)
            {
                    transform.position -= new Vector3(0.0f, 100.0f * dt, 0.0f);
            }

            else
            {
                GameObject.FindGameObjectWithTag("ZoomTransition").GetComponent<ZoomTransition>().endScreen = true;
            }

            ChangeTextures();
        }

        time += dt * 10.0f;
    }


    void ChangeTextures()
    {

        switch ((int)time % 3)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = textures[0];
                break;

            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = textures[1];
                break;

            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = textures[2];
                break;

            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = textures[3];
                break;
        }
    }
}
