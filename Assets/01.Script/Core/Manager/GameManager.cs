using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleTon<GameManager>
{
    #region ¾À

    public void Awake()
    {
        JsonManager.DisplayData();
        JsonManager.Load();
    }

    public void OnApplicationQuit()
    {
        JsonManager.Save();
    }

    public void LoadMenu()
    {
        LoadingSceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        if (!JsonManager.Data.hasSawTrail)
        {
            LoadingSceneManager.LoadScene(3);
        }
        else
        {
            LoadingSceneManager.LoadScene(1);
        }
    }
    public void LoadStation()
    {
        LoadingSceneManager.LoadScene(2);
    }   

    public void LoadDemoEnding()
    {
        LoadingSceneManager.LoadScene(5);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
    public void ExitStation()
    {
        JsonManager.Data.curStationIndex++;
        JsonManager.Save();
        LoadGame();
    }
}
