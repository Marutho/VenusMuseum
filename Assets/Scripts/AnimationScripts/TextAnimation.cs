using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    public Sprite t1;
    public Sprite t2;
    public Vector3 targetPosition;

    private float time;

    private void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        if (transform.position.y > targetPosition.y)
        {
            if(transform.localScale.x < 0.71)
            {
                Vector3 nextPosition = transform.position - new Vector3(0.0f, 5.0f * dt, 0.0f);
                if (nextPosition.y > targetPosition.y)
                    transform.position = new Vector3(transform.position.x, targetPosition.y, transform.position.z);
                else
                    transform.position = nextPosition;
            }
                
            else
                transform.position -= new Vector3(0.0f, 250.0f * dt, 0.0f);

        }

        ChangeTextures();

        time += dt * 10.0f;

    }

    void ChangeTextures()
    {

        if ((int)time % 2 == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = t1;
        }

        else if ((int)time % 2 != 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = t2;
        }
    }
}
