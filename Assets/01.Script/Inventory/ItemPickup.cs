using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemDataSO item;

    void PickUp()
    {
        InventoryHandler.Instance.Add(item);
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        PickUp();
    }
}
