using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleTon<GameManager>
{
    #region ¾À
    public void LoadMenu()
    {
        LoadingSceneManager.LoadScene(0);
        //SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        if (!JsonManager.Instance.Data.hasSawTrail)
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

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}
