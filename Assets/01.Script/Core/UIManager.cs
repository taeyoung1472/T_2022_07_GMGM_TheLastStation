using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleTon<UIManager>
{
    #region 플레이어 카드 UI 관련
    [Header("플레이어 카드 UI 관련")]
    [SerializeField] private TextMeshProUGUI characterCardName;
    [SerializeField] private TextMeshProUGUI characterCardDesc;
    [SerializeField] private Image characterCardProfile;
    #endregion

    public void SetCharacterCardInfo(CharacterData data)
    {
        characterCardName.text = data.name;
        characterCardDesc.text = data.desc;
        characterCardProfile.sprite = data.profile;
    }
}
