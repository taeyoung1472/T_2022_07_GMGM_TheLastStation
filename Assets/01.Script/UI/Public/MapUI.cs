using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor.ShaderGraph.Serialization;

public class MapUI : MonoBehaviour
{
    private TextMeshProUGUI stationName;
    private TextMeshProUGUI stationDesc;
    private Image stationProfile;

    private bool isActive = false;

    private void Find()
    {
        stationName = transform.Find("Background/Preview/StationName").GetComponent<TextMeshProUGUI>();
        stationDesc = transform.Find("Background/Preview/StationDesc").GetComponent<TextMeshProUGUI>();
        stationProfile = transform.Find("Background/Preview/Background/StationProfile").GetComponent<Image>();
    }

    public void SetData(StationDataSO data)
    {
        Find();
        stationName.text = $"{data.stationName}";
        stationDesc.text = $"{data.stationDesc}";
        stationProfile.sprite = data.profileImage;
    }

    public void Active()
    {
        isActive = !isActive;

        gameObject.SetActive(isActive);
    }
}
