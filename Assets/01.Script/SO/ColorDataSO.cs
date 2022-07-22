using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Color")]
public class ColorDataSO : ScriptableObject
{
    [Header("Rare Color")]
    public Color commonColor     = Color.white;
    public Color unCommonColor   = Color.white;
    public Color rareColor       = Color.white;
    public Color legendColor     = Color.white;
}
