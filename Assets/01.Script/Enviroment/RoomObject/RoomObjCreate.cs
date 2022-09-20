using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjects
{
    void Effect(int roomWidth = 1);
}
public class RoomObjCreate : MonoBehaviour
{
    [Header("��ġ ������Ʈ")]

    [SerializeField]
    GameObject[] RoomObjs;
    public int roomWidth;

    public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> objectPool = new List<GameObject>();


    private void Start()
    {
        //���� �濡 �� �� ����ǵ��� ����
        Transform spawnPointEx = GameObject.Find("SpawnPointEx")?.transform;
        Transform objCreatePoint = this.transform;

        foreach(Transform oP in objCreatePoint)
        {
            spawnPoints.Add(oP);
        }
        CreatePool();
        CreateObjs();
    }
    public void CreateObjs()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            GameObject _obj = GetInPool();
            _obj?.transform.SetParent(this.transform);
            _obj?.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            _obj?.SetActive(true);
        }
    }

    public void CreatePool()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            var spawnValue = spawnPoints[i]?.GetComponent<StateValue>();
            var _obj = Instantiate<GameObject>(RoomObjs[(int)spawnValue.spawnState]);
            if(spawnValue.spawnState == SpawnState.ITEMBOX)
            {
                switch(Random.Range(0, 2))
                {
                    case 0:
                        Destroy(_obj);
                        return;
                    case 1:
                        break;
                }
            }
            _obj.name = spawnValue.spawnState.ToString();
            _obj.SetActive(false);
            objectPool.Add(_obj);
        }
    }

    public GameObject GetInPool()
    {
        foreach (var _object in objectPool)
        {
            if (!_object.activeSelf)
                return _object;
        }

        return null;
    }
}
