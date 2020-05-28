using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int direction = 1;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        transform.position += new Vector3(direction * dt * speed * 30.0f * GameManager.instance.tennisSpeedMultiplier, 0.0f);

        if(direction==1)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, transform.position.z - speed));
        }

        else if(direction==-1)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, transform.position.z + speed));
        }

    }

}
