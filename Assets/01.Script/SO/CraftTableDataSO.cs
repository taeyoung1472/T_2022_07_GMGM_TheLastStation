using UnityEngine;

[CreateAssetMenu(menuName = "SO/CraftTableData")]
public class CraftTableDataSO : ScriptableObject
{
    [Header("[����]")]
    public string tableName = "���� ���̺�";
    public string tableDesc = "���� ����";
    [Header("[�����͵�]")]
    public CraftDataSO[] craftDatas;
}
