using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomTransition : MonoBehaviour
{
    
    public float scalingSpeed;
    public RawImage texturePaint;
    public Transform painting;
    public RectTransform lives;
    public bool endScreen;


    private bool isEyeClosing;
    private bool isEyeOpening;
    private RectTransform sceneObj;
    private float timePassed;
    private EyeAnimation_Manager eye;
    private bool transitionToLeft;
    



    void Start()
    {
        endScreen = false;
        transitionToLeft = true;
        texturePaint.texture = GameManager.instance.textureToLoad;
        sceneObj = gameObject.GetComponent<RectTransform>();
        GameManager.instance.timeMultiplier = 1.0f;

        if (GameManager.instance.backToPainting == true)
        {
            sceneObj.localScale = new Vector3(5.0f, 5.0f, 1.0f);

        }

        GameManager.instance.win = false;
        GameManager.instance.lose = false;


        isEyeClosing = false;
        isEyeOpening = false;

        timePassed = 0.0f;
        scalingSpeed = 15.0f;

        eye = GameObject.FindGameObjectWithTag("Eyes").GetComponent<EyeAnimation_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        
        if (!GameManager.instance.backToPainting)
        {
            ZoomIn(dt);
        }

        if (GameManager.instance.backToPainting)
        {
            ZoomOut(dt);
        }

        timePassed += dt;
    }

    void ZoomIn(float dt)
    {
        if (timePassed > 3.5f && sceneObj.localScale.x < 5.0f)
        {
            lives.position += new Vector3(0.0f, scalingSpeed * 1000.0f * dt, 0.0f);
            sceneObj.localScale += new Vector3(scalingSpeed * dt, scalingSpeed * dt, 0.0f);

            if (!isEyeClosing)
            {
                eye.eState = EyeAnimation_Manager.EyeState.Closing;
                isEyeClosing = true;
            }
        }
    }

    void ZoomOut(float dt)
    {
        if (timePassed < 3.5f && sceneObj.localScale.x > 1.0f)
        {
            Vector3 newScale = sceneObj.localScale - new Vector3(scalingSpeed * dt, scalingSpeed * dt, 0.0f);


            if (newScale.x < 1.0f)
            {
                newScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            

            sceneObj.localScale = newScale;

            if (!isEyeOpening)
            {
                eye.eState = EyeAnimation_Manager.EyeState.Opening;
                isEyeOpening = true;
            }
        }

        else if (GameManager.instance.switchToNextPainting && timePassed > 2.0f)
        {
            SwitchPainting(dt);
            
        }
    }

    void SwitchPainting(float dt)
    {
        if(GameManager.instance.exitGame)
        {
            if(endScreen)
            {
                GameManager.instance.backToPainting = false;
            }
            
        }

        else
        {
            if (transitionToLeft)
            {
                if (painting.localPosition.x > -1300.0f)
                    painting.localPosition -= new Vector3(3000.0f * dt, 0.0f, 0.0f);

                else
                {
                    transitionToLeft = false;
                    painting.localPosition = new Vector3(1300.0f, painting.localPosition.y, painting.localPosition.z);
                    GameManager.instance.GetNextPaintingTexture();
                    texturePaint.texture = GameManager.instance.textureToLoad;
                }

            }

            else
            {

                if (painting.localPosition.x > 0.0f)
                {
                    painting.localPosition -= new Vector3(3000.0f * dt, 0.0f, 0.0f);
                    if (painting.localPosition.x < 0.0f)
                        painting.localPosition = new Vector3(0.0f, painting.localPosition.y, painting.localPosition.z);
                }


                else
                {
                    GameManager.instance.switchToNextPainting = false;
                    StartCoroutine(WaitForZoomIn());
                }
            }
        }
        
     
    }

    IEnumerator WaitForZoomIn()
    {
        yield return new WaitForSeconds(1.0f);
        GameManager.instance.backToPainting = false;
    }
}
