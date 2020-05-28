using UnityEngine;
using UnityEngine.Events;

public class EyeAnimation_Manager : MonoBehaviour
{
    public SceneTransition_Manager stManager;
    public GameObject eyeUp;
    public GameObject eyeDown;
    public float eyeMoveSpeed;
    public enum EyeState
    {
        Closing,
        Closed,
        SwitchingPainting,
        Opening,
        Open
    };


    public EyeState eState;
    private RectTransform eyeUpRect;
    private RectTransform eyeDownRect;
    private Vector3[] eyeOriginalPositions;


    void Awake()
    {
        eState = EyeState.Opening;
        eyeMoveSpeed = 1000.0f;
        eyeOriginalPositions = new Vector3[2];
        eyeUpRect = eyeUp.GetComponent<RectTransform>();
        eyeDownRect = eyeDown.GetComponent<RectTransform>();
        eyeOriginalPositions[0] = eyeUpRect.localPosition;
        eyeOriginalPositions[1] = eyeDownRect.localPosition;
    }

    void Start()
    {
        stManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneTransition_Manager>();
    }

    void Update()
    {
        if (eState == EyeState.Opening)
        {
            OpenEyes();
        }

        if (eState == EyeState.Closing)
        {
            CloseEyes();
        }

    }

    void CloseEyes()
    {
        float dt = Time.deltaTime;

        if (eyeUpRect.localPosition.y > eyeOriginalPositions[0].y)
        {
            eyeUpRect.localPosition -= new Vector3(0.0f, dt * eyeMoveSpeed, 0.0f);
        }

        if (eyeDownRect.localPosition.y < eyeOriginalPositions[1].y)
        {
            eyeDownRect.localPosition += new Vector3(0.0f, dt * eyeMoveSpeed, 0.0f);
        }

        else
        {
            eState = EyeState.Closed;
            SceneTransition_Manager.instance.GetLevelState();
        }

    }

    void OpenEyes()
    {
        float dt = Time.deltaTime;

        if (eyeUpRect.localPosition.y < 200)
        {
            eyeUpRect.localPosition += new Vector3(0.0f, dt * eyeMoveSpeed, 0.0f);
        }

        if (eyeDownRect.localPosition.y > -200)
        {
            eyeDownRect.localPosition -= new Vector3(0.0f, dt * eyeMoveSpeed, 0.0f);
        }

        else
        {
            eState = EyeState.Open;
            if(GameManager.instance.switchToNextPainting == true)
            {
                eState = EyeState.SwitchingPainting;
            }
        }
    }


}
