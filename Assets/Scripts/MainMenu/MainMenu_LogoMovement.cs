using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_LogoMovement : MonoBehaviour
{

    private Vector3 og_scale;
    private RectTransform rect;
    private float time;
    private bool timeControl;
    [Range(0.1f, 2.0f)] public float scaleSpeed;

    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();

        og_scale.x = rect.localScale.x;
        og_scale.y = rect.localScale.y;
        time = 0.0f;
        timeControl = false;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        InterpolateTime(dt);
        rect.localScale = Vector3.Lerp(og_scale, 1.2f * og_scale, time);
    }

    void InterpolateTime(float dt)
    {
        if (time < 1.0f && !timeControl)
        {
            time += dt * scaleSpeed;
            if (time > 1.0f)
            {
                time = 1.0f;
                timeControl = true;
            }
        }

        else if (time > 0.0f && timeControl)
        {
            time -= dt * scaleSpeed;
            if (time < 0.0f)
            {
                time = 0.0f;
                timeControl = false;
            }
        }

    }
}
