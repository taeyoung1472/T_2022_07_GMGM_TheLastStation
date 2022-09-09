using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Pharming")]
public class PharmingDataSO : ScriptableObject
{
    public string pharmingName;
    public MapPattern mapPattern;

    [Range(0, 3)] public int pharmingDangerLevel;
}
