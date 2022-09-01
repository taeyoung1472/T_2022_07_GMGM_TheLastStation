using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationGenerator : MonoBehaviour
{
    [SerializeField] private StationDataSO demoData;

    [SerializeField] private Vector2Int standardUnit;

    [SerializeField] private List<Room> roomList = new List<Room>();
    [SerializeField] private List<Room> stairList = new List<Room>();

    [ContextMenu("Generate")]
    public void GenerateStation()
    {

    }
}
