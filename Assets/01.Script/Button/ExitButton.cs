using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField]
    private GameObject exitPanel;

    private void Start()
    {
        exitPanel.SetActive(false);
    }

    public void OnClickExitBtn()
    {
        exitPanel.SetActive(true);
    }

    public void OnClickMumurBtn()
    {
        exitPanel.SetActive(false);
    }
}
