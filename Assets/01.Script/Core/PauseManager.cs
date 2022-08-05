using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isPause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Active();
        }
    }
    public void Active()
    {
        isPause = !isPause;
        pausePanel.SetActive(isPause);
        Time.timeScale = isPause ? 0 : 1;
        if (isPause)
        {
            UISoundManager.Instance.Open();
        }
        else
        {
            UISoundManager.Instance.Close();
        }
    }
}
