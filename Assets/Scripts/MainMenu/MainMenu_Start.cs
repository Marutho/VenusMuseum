using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu_Start : MonoBehaviour
{

    [Range(0.1f, 2.0f)] public float scaleSpeed;

    public Texture mouseOverTexture;
    
    private Texture ogTexture;
    private RectTransform rect;
    private Vector3 og_scale;
    private float time;
    private bool timeControl;

    void Start()
    {
        ogTexture = gameObject.GetComponent<RawImage>().texture;
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
        rect.localScale = Vector3.Lerp(og_scale, 1.05f * og_scale, time);
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

    private void OnMouseOver()
    {
        gameObject.GetComponent<RawImage>().texture = mouseOverTexture;
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<RawImage>().texture = ogTexture;
    }

    private void OnMouseDown()
    {
        GameManager.instance.ResetGame();
        SceneTransition_Manager.instance.ResetGame();

        EyeAnimation_Manager eyeMg = GameObject.FindGameObjectWithTag("Eyes").GetComponent<EyeAnimation_Manager>();
        eyeMg.eState = EyeAnimation_Manager.EyeState.Closing;
    }
}
