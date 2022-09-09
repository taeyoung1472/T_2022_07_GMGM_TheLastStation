using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardUI : MonoBehaviour
{
    [Header("플레이어 카드 UI 관련")]
    [SerializeField] private RectTransform playerCard;
    [SerializeField] private TextMeshProUGUI characterCardName;
    [SerializeField] private TextMeshProUGUI characterCardDesc;
    [SerializeField] private Image characterCardProfile;
    private CharacterData prevData;

    public void SetCharacterCardInfo(CharacterData data)
    {
        if (prevData == data) return;
        Sequence seq = DOTween.Sequence();
        //OnOffSound(false);
        seq.Append(playerCard.DOAnchorPosY(-300, 0.5f));
        seq.AppendCallback(() =>
        {
            characterCardName.text = data.name;
            characterCardDesc.text = data.desc;
            characterCardProfile.sprite = data.profile;
            //OnOffSound(true);
        });
        seq.Append(playerCard.DOAnchorPosY(0, 0.5f));
        prevData = data;
    }
}
