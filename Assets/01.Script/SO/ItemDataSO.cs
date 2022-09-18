using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/ItemData")]
public class ItemDataSO : ScriptableObject
{
    [Header("�⺻ ���")]
    public Sprite itemSprite;
    public ItemCategory category;
    public int itemId;
    public int maxStackAbleCount = 32;
    public string itemName = "������ �̸�";
    [TextArea(5, 1)]
    public string itemDesc = "������ ����";
    [Header("Drop ����")]
    public int dropWeight = 1;

}
public enum ItemCategory
{
    Production,
    Food
}