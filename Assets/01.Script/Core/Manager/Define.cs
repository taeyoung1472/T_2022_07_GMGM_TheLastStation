using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoSingleTon<Define>
{
    [SerializeField] private ColorDataSO colorData;
    public ColorDataSO ColorData { get { return colorData; } }
}
