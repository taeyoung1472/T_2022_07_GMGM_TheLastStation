using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/StationData")]
public class StationDataSO : ScriptableObject
{
    public string stationName;
    [TextArea(5,5)]
    public string stationDesc;
    public Sprite profileImage;
    public List<BackgroundData> backgroundDatas;
    public List<PharmingDataSO> pharmingDatas;

    [ContextMenu("����üũ")]
    public void CheckLength()
    {
        int length = 0;
        for (int i = 0; i < backgroundDatas.Count; i++)
        {
            length += backgroundDatas[i].length;
        }
        Debug.Log($"\"{stationName}\"�뼱�� �� ���� : {length}");
    }
}