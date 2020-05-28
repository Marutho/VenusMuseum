using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBallInBounds : MonoBehaviour
{
    public bool winCondition;

    private int collisionCount = 0;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsNotColliding)
        {
            GameManager.instance.lose = true;
            GameManager.instance.win = false;
        }

        if (!IsNotColliding)
        {
            GameManager.instance.win = true;
            GameManager.instance.lose = false;

        }
    }

    

    public bool IsNotColliding
    {
        get { return collisionCount == 0; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount--;
    }
   
}
