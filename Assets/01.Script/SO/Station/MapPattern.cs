using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/MapPattern")]
public class MapPattern : ScriptableObject
{
    public StationZoneData[] roomZones;
}

[System.Serializable]
public class StationZoneData
{
    public ZoneType[] zoonTypes;
}
public enum ZoneType
{
    Empty,
    Stair,
    FarmingRoom,
    CombatRoom,
    EmptyRoom,
    Bridge,
    Garden,
}