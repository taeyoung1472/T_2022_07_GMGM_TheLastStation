using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private int randomItemDropCount;
    [SerializeField] private ItemDataSO[] items;
    private Door[] doors;

    private bool isOpened = false;

    private void Start()
    {
        doors = FindObjectsOfType<Door>();
    }

    public void Test()
    {
        if (!isOpened)
        {
            isOpened = true;
            foreach (var item in items)
            {
                print($"{item.name}이 {item.prefab.dropableCount}개만큼 나왔다!");
                if(item.itemId == 100)
                {
                    foreach (var door in doors)
                        door.IsHaveKey = true;
                }
            }
            for (int i = 0; i < randomItemDropCount; i++)
            {
                if (Generate() != null)
                    print($"{Generate().name}이 나왔다!");
            }
        }
    }
    public ItemDataSO Generate()
    {
        int totalWeight = 0;
        int check = 0;
        for (int i = 0; i < items.Length; i++)//총 가중치 값 구하기
        {
            totalWeight += items[i].dropWeight;
        }

        int rand = Random.Range(1, totalWeight + 1);
        for (int i = 0; i < items.Length; i++)//하나하나 더해가면서 가중치 안에 있는지 체크
        {
            check += items[i].dropWeight;
            if (rand <= check)
            {
                return items[i];
            }
        }
        return null;
    }
}
