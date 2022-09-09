using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationGenerator : MonoSingleTon<StationGenerator>
{
    [SerializeField] private Vector2Int standardUnit;

    [SerializeField] private List<TypeMatchRoom> roomList = new List<TypeMatchRoom>();
    Dictionary<ZoneType, TypeMatchRoom> typeMatchRoomDic = new Dictionary<ZoneType, TypeMatchRoom>();

    private int prevFloor;
    private int nextFloor;
    private bool isGenerated = false;

    ZoneType[,] zoneTypeMap = new ZoneType[100, 100];

    private void Init()
    {
        typeMatchRoomDic.Clear();
        foreach (TypeMatchRoom matchRoom in roomList)
        {
            typeMatchRoomDic.Add(matchRoom.type, matchRoom);
        }
    }

    public void GenerateStation(MapPattern pattern)
    {
        if (isGenerated) { Debug.Log("map has been generated."); return; }
        isGenerated = true;
        Init();

        int x = 0, y = 0;
        foreach (var zone in pattern.roomZones)
        {
            foreach (var type in zone.zoonTypes)
            {
                zoneTypeMap[x, y] = type;
                y++;
            }
            x++;
            y = 0;
        }
        GenerateRoom();
    }

    private void GenerateRoom()
    {
        int stackCount = 0;
        ZoneType prevType = ZoneType.Empty;

        for (int y = 0; y < zoneTypeMap.GetLength(1); y++)
        {
            for (int x = 0; x < zoneTypeMap.GetLength(0); x++)
            {
                if (prevType == ZoneType.Empty) { /* 아무것도 안함 */ }
                else if (prevType == zoneTypeMap[x, y])
                {
                    stackCount++;
                }
                else if (prevType != zoneTypeMap[x, y])
                {
                    GenerateRoom(prevType, stackCount, x, y);
                    stackCount = 0;
                }
                prevType = zoneTypeMap[x, y];
            }
        }
    }

    private void GenerateRoom(ZoneType type, int length, int x, int y)
    {
        print($"Enum : {type}, Length : {length}");
        Room tgtRoom = typeMatchRoomDic[type].rooms[length];
        Instantiate(tgtRoom.gameObject, new Vector3((x - length) * standardUnit.x, (y - 1) * standardUnit.y, 0), Quaternion.identity).GetComponent<Room>().Init(type);
    }

    [System.Serializable]
    public class TypeMatchRoom
    {
        public ZoneType type;
        public Room[] rooms;
    }
}