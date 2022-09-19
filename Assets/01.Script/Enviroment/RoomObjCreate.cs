using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjects
{
    void Effect(int roomWidth = 1);
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
    [SerializeField]
    private int roomWidth;

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
