using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjects
{
    void Effect(int roomWidth = 1);
}
public interface IItemDroppers
{
    //게임오브젝트를 받아와서 그 게임오브젝트 종류에 따라 드롭하는 아이템 변경
    //냉장고는 음식 아이템, 의료용 선반은 약품 아이템을 드롭함
    void ItemDrop();
    
}
public class Corpse : IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //시체: 20% 확률로 등장, 캐릭터 정신력 초당 1 감소
        //썩은 시체: 5% 확률로 등장, 캐릭터 정신력 초당 1 감소, 이동속도 감소
        //일단 시체가 나왔다면 4/5 확률로 일반 시체고 1/5 확률로 썩은 시체
        //방 길이 따라 달라지네?
    }
}
public class Ruin : IObjects
{
    public void Effect(int roomWidth = 1)
    {
        //건물 잔해: 20% 확률로 등장, '삽' 도구로 상호작용해서 제거
        //철골 잔해: 10% 확률로 등장, '줄톱' 도구로 상호작용해서 제거
    }
}
public class RoomObjCreate : MonoBehaviour
{
    [Header("배치 오브젝트")]

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
        //추후 방에 들어갈 때 실행되도록 조정
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
