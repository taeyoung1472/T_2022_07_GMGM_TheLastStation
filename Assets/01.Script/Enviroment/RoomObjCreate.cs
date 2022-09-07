using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjects
{
    void Effect(int roomWidth = 1);
}
public interface IItemDroppers
{
    //���ӿ�����Ʈ�� �޾ƿͼ� �� ���ӿ�����Ʈ ������ ���� ����ϴ� ������ ����
    //������ ���� ������, �Ƿ�� ������ ��ǰ �������� �����
    void ItemDrop();
    
}
public class Corpse : IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //��ü: 20% Ȯ���� ����, ĳ���� ���ŷ� �ʴ� 1 ����
        //���� ��ü: 5% Ȯ���� ����, ĳ���� ���ŷ� �ʴ� 1 ����, �̵��ӵ� ����
        //�ϴ� ��ü�� ���Դٸ� 4/5 Ȯ���� �Ϲ� ��ü�� 1/5 Ȯ���� ���� ��ü
        //�� ���� ���� �޶�����?
    }
}
public class Ruin : IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //�ǹ� ����: 20% Ȯ���� ����, '��' ������ ��ȣ�ۿ��ؼ� ����
        //ö�� ����: 10% Ȯ���� ����, '����' ������ ��ȣ�ۿ��ؼ� ����
    }
}
public class RoomObjCreate : MonoBehaviour
{
    [Header("��ġ ������Ʈ")]

    [SerializeField]
    private GameObject corpse;
    [SerializeField]
    private GameObject itemBox;
    [SerializeField]
    private GameObject ruin;

    public List<Transform> spawnPoints = new List<Transform>();

    private IObjects obj;

    private void Start()
    {
        //���� �濡 �� �� ����ǵ��� ����
        Transform objCreatePoint = this.transform;
        foreach(Transform oP in objCreatePoint)
        {
            spawnPoints.Add(oP);
        }
        obj.Effect();
    }
    public void CreateObjs()
    {
        int idx = spawnPoints.Count;

        GameObject _obj = new GameObject();
        _obj?.transform.SetPositionAndRotation(spawnPoints[idx].position, spawnPoints[idx].rotation);
    }
}
