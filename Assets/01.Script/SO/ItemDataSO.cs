using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/ItemData")]
public class ItemDataSO : ScriptableObject
{
    [Header("기본 재원")]
    public Sprite itemSprite;
    public ItemCategory category;
    public int itemId;
    public int maxStackAbleCount = 32;
    public string itemName = "아이템 이름";
    [TextArea(5, 1)]
    public string itemDesc = "아이템 설명";
    [Header("Drop 관련")]
    public int dropWeight = 1;

}
public enum ItemCategory
{
    Production,
    Food
}