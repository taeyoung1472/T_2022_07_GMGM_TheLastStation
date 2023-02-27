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
    //public int temp;

    /*[ContextMenu("Rename")]
    public void Rename()
    {
        Utility.RenameFile("Assets/06.SO/Item/Item", $"{name}.asset", $"{itemId}. {itemName}.asset");
        Debug.Log($"Name : {name}");
    }*/

    public void SetIndex()
    {
        Debug.Log("SET INDEX");
        if (name.Contains("ID "))
        {
            itemId = Utility.ParseStringToInt(name.Replace("ID ", ""));
        }
    }

    public void LoadData(GoogleSheetData data)
    {
        Debug.Log("LOAD DATA");
        itemId = Utility.ParseStringToInt(data.cell[(int)ItemIndex.ID]);
        category = Utility.ParseStringToEnum<ItemCategory>(data.cell[(int)ItemIndex.Category]);
        itemName = data.cell[(int)ItemIndex.Name];
        itemDesc = data.cell[(int)ItemIndex.Desc];
        maxStackAbleCount = Utility.ParseStringToInt(data.cell[(int)ItemIndex.MaxStackAbleCount]);
        dropWeight = Utility.ParseStringToInt(data.cell[(int)ItemIndex.DropWeight]);
    }
}
public enum ItemCategory
{
    Food,
    Weapon,
    Material,
    Armor,
    Medicine,
    furniture,
    ProductionTable,
    Tool,
    HighQualityMaterial,
    TurretModule,
    ETC
}