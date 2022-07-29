using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoSingleTon<MenuManager>
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
