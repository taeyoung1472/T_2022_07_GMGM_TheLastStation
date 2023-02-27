using UnityEngine;

[CreateAssetMenu(menuName = "SO/CraftTableData")]
public class CraftTableDataSO : ScriptableObject
{
    [Header("[정보]")]
    public string tableName = "제작 테이블";
    public string tableDesc = "제작 설명";
    [Header("[데이터들]")]
    public CraftDataSO[] craftDatas;
}
