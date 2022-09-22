using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardUI : MonoBehaviour
{
    private RectTransform rectTransform;

    private TextMeshProUGUI characterNameTmp;
    private TextMeshProUGUI characterDescTmp;

    private Image characterProfileImage;
    private CharacterData prevData = null;

    Sequence changeSeq;
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        characterNameTmp = transform.Find("CharacterName").GetComponent<TextMeshProUGUI>();
        characterDescTmp = transform.Find("CharacterDesc").GetComponent<TextMeshProUGUI>();
        characterProfileImage = transform.Find("Profile/CharacterProfile").GetComponent<Image>();
    }

    public void ChangeCardUI(CharacterData data)
    {
        if (data == prevData)
            return;

        changeSeq = DOTween.Sequence();

        changeSeq.Append(rectTransform.DOAnchorPosY(-rectTransform.sizeDelta.y * 2, 0.25f));
        changeSeq.AppendCallback(() =>
        {
            characterNameTmp.text = $"{data.name}";
            characterDescTmp.text = $"{data.desc}";
            characterProfileImage.sprite = data.profile;
        });
        changeSeq.Append(rectTransform.DOAnchorPosY(0, 0.25f));
        prevData = data;
    }
}