using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleTon<GameManager>
{
    #region ¾À
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGame()
    {
        if (!JsonManager.Instance.Data.hasSawTrail)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void LoadStation()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}
