using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemCraft : MonoBehaviour
{
    [SerializeField] private Image profileImage;
    Sprite prevSprite;
    CraftDataSO craftData;
    public void Set(CraftDataSO data)
    {
        craftData = data;
        if(prevSprite == null)
        {
            prevSprite = profileImage.sprite;
        }
        if (craftData == null)
        {
            profileImage.sprite = prevSprite;
            return;
        }
        profileImage.sprite = craftData.targetItem.profileImage;
    }
    public void Click()
    {
        if(craftData == null)
        {
            return;
        }
        UIManager.Instance.SetCraftTableUI(craftData);
    }
}
