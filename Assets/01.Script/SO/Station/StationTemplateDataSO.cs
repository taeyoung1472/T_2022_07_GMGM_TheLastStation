using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/StationTemplate")]
public class StationTemplateDataSO : ScriptableObject
{
    public string templateName;
    public string templateDesc;
    public StationZoneData[] stationZones;
}
[System.Serializable]
public class StationZoneData
{
    public ZoneType zoneType;
    public Vector2Int zoonSize;
}
public enum ZoneType
{
    Stair,
    Room
}