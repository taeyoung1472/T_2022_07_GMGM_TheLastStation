using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/ItemData")]
public class ItemDataSO : ScriptableObject
{
    public int id;
    [Header("기본 재원")]
    public Sprite profileImage;
    public RareRate rareRate;
    public string name = "아이템 이름";
    [TextArea(5, 1)]
    public string desc = "아이템 설명";
    public int maxStackAbleCount = 32;
    [Header("Drop 관련")]
    public int dropWeight = 1;
    public enum ItemType
    {
        Production,
        Food
    }
    public ItemType itemType;


}