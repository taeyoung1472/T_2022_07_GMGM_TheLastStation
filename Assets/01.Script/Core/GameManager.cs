using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleTon<GameManager>
{
    [SerializeField] private AudioMixerGroup effectGroup;
    public AudioMixerGroup EffectGroup { get { return effectGroup; } }
    #region ¾À
    public void LoadMenu()
    {
        LoadingSceneManager.LoadScene(0);
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
        JsonManager.Instance.Data.curStationIndex++;
        JsonManager.Instance.Save();
        LoadGame();
    }
}
