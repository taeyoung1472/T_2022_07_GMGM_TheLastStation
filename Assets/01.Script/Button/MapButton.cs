using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] private GameObject mapPanel;

    private void Start()
    {
        mapPanel.SetActive(false);
    }
    public void OnClickBtn()
    {
        mapPanel.SetActive(true);
    }
    public void OnClickCloseBtn()
    {
        mapPanel.SetActive(false);
    }
}
