using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Texture[] paintingTextures;
    public bool backToPainting;
    public bool switchToNextPainting;
    public Texture textureToLoad;
    public float timeMultiplier;
    public float difficulty;
    public float tennisSpeedMultiplier;
    public int totalLives;
    public bool exitGame;

    public bool win;
    public bool lose;


    //GUIA PARA LAS TEXTURAS QUE CARGAR
    /* 0 - Agustina Standard
     * 1 - Agustina Perdida
     * 2 - Agustina Win
     * 3 - Conchi Normal
     * 4 - Conchi Lose
     * 5 - Conchi Win
     * 6 - Marie Normal
     * 7 - Marie Lose
     * 8 - Marie Win
     * 9 - Catalan Normal
     * 10 - Catalan Lose
     * 11 - Catalan Win
    */

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        exitGame = false;
        totalLives = 4;
        win = false;
        lose = false;
        textureToLoad = paintingTextures[0];
        timeMultiplier = 1.0f;
        difficulty = 1.1f;
        backToPainting = false;
        tennisSpeedMultiplier = 1.0f;
        switchToNextPainting = false;
    }

    public void ResetGame()
    {
        Debug.Log("I'm calling the ResetGame from GameManager.");

        instance.exitGame = false;
        instance.totalLives = 4;
        instance.win = false;
        instance.lose = false;
        instance.textureToLoad = paintingTextures[0];
        instance.timeMultiplier = 1.0f;
        instance.difficulty = 1.1f;
        instance.backToPainting = false;
        instance.tennisSpeedMultiplier = 1.0f;
        instance.switchToNextPainting = false;
    }

    void Update()
    {
        CheckDifficulty();
    }

    void CheckDifficulty()
    {

        switch(SceneTransition_Manager.instance.nextMinigame)
        {
            case 5:
                difficulty = 1.25f;
                break;

            case 10:
                difficulty = 1.45f;
                break;

            case 15:
                difficulty = 1.75f;
                break;

            case 20:
                difficulty = 2.0f;
                break;
        }
    }
    // Update is called once per frame
    
    public void UpdateNextTextureToLoad(int n)
    {
        textureToLoad = paintingTextures[n];
    }

    public void GetNextPaintingTexture()
    {
        int number = SceneTransition_Manager.instance.nextMinigame;

        number %= 12;
        if (number == 0)
            number = 1;

        if (number == 1 || number == 5 || number == 9)
            UpdateNextTextureToLoad(0);

        else if (number == 2 || number == 6 || number == 10)
            UpdateNextTextureToLoad(3);

        else if (number == 3 || number == 7)
            UpdateNextTextureToLoad(6);

        else if (number == 4 || number == 8 || number == 11)
            UpdateNextTextureToLoad(9);
    }

}


