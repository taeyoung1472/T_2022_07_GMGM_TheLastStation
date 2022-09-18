using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inventoryNameTMP;
    [SerializeField] private TextMeshProUGUI inventoryDescTMP;
    private bool isActive;

    public void SetUI(ItemDataSO data)
    {
        inventoryNameTMP.text = data.itemName;
        inventoryDescTMP.text = data.itemDesc;
    }
    public void Active()
    {
        isActive = !isActive;

        gameObject.SetActive(isActive);
    }
}
