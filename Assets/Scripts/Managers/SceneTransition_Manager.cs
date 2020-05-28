using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition_Manager : MonoBehaviour
{
    public static SceneTransition_Manager instance;
    public int nextMinigame;
    public int numberOfLevels;
    public int currentScene;
    
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

    private void Start()
    {
        nextMinigame = 1;
        numberOfLevels = 11;
    }

    public void ResetGame()
    {
        Debug.Log("I'm calling the SceneTransition reset.");
        instance.nextMinigame = 1;
        instance.numberOfLevels = 11;
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("This is updating with CurrentScene " + currentScene);
        Debug.Log("The next Minigame is " + nextMinigame);
    }

    public void LoadPaintingScene()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadFinalScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GetPaintingForMinigame(int minigame)
    {
        if(minigame == 1 || minigame == 5 || minigame == 9)
            GameManager.instance.UpdateNextTextureToLoad(0);

        else if(minigame == 2 || minigame == 6 || minigame == 10)
            GameManager.instance.UpdateNextTextureToLoad(3);

        else if(minigame == 3 || minigame == 7)
            GameManager.instance.UpdateNextTextureToLoad(6);

        else if (minigame == 4 || minigame == 8 || minigame == 11)
            GameManager.instance.UpdateNextTextureToLoad(6);
    }
    public void GetLevelState()
    {
        Debug.Log("I'm entering the GetLevelState on CurrentScene " + currentScene);

        if (GameManager.instance.exitGame)
        {
            LoadFinalScene();
        }

        else if(currentScene == 0)
        {
            LoadPaintingScene();
        }

        else if(currentScene == 1)
        {

            if (numberOfLevels + 1 > nextMinigame)
            {
                nextMinigame++;
                SceneManager.LoadScene(nextMinigame);
            }

            else
            {
                
                //
                //nextMinigame = 1;
                //GameManager.instance.UpdateNextTextureToLoad(0);
                //SceneManager.LoadScene(2);
            }
        }

        else if (currentScene == 2 || currentScene == 6 || currentScene == 10 )
        {
            if (GameManager.instance.win)
                GameManager.instance.UpdateNextTextureToLoad(2);

            if (GameManager.instance.lose)
                GameManager.instance.UpdateNextTextureToLoad(1);

            GameManager.instance.switchToNextPainting = true;
            LoadPaintingScene();
        }

        else if (currentScene == 3 || currentScene == 7 || currentScene == 11)
        {
            if (GameManager.instance.win)
                GameManager.instance.UpdateNextTextureToLoad(5);

            if (GameManager.instance.lose)
                GameManager.instance.UpdateNextTextureToLoad(4);

            GameManager.instance.tennisSpeedMultiplier += 0.15f;

            GameManager.instance.switchToNextPainting = true;
            LoadPaintingScene();
        }

        else if(currentScene == 4 || currentScene == 8)
        {

            if (GameManager.instance.win)
                GameManager.instance.UpdateNextTextureToLoad(8);

            if (GameManager.instance.lose)
                GameManager.instance.UpdateNextTextureToLoad(7);

            GameManager.instance.switchToNextPainting = true;
            LoadPaintingScene();
        }

        else if (currentScene == 5 || currentScene == 9 || currentScene == 12)
        {

            if (GameManager.instance.win)
                GameManager.instance.UpdateNextTextureToLoad(11);

            if (GameManager.instance.lose)
                GameManager.instance.UpdateNextTextureToLoad(10);

            GameManager.instance.switchToNextPainting = true;

            if(currentScene == 12)
                GameManager.instance.exitGame = true;

            LoadPaintingScene();
        }
    }

}