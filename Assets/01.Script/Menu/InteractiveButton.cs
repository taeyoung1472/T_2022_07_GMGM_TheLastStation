using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class InteractiveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color activeColor = Color.white;
    [SerializeField] private float activeMoveValue = 0;
    [SerializeField] private float activeSizeValue = 1;
    [SerializeField] private AudioClip activeClip;
    private Image image;
    private RectTransform rectTransform;
    private Color originColor;
    private float originPos;
    public void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        originPos = rectTransform.anchoredPosition.x;
        originColor = image.color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Kill();

        rectTransform.DOAnchorPosX(originPos + activeMoveValue, 0.25f).SetUpdate(true);
        rectTransform.DOScale(activeSizeValue, 0.2f).SetUpdate(true);
        image.DOColor(activeColor, 0.2f).SetUpdate(true);
        if(activeClip != null)
        {
            AudioManager.Play(activeClip, Random.Range(0.9f, 1.1f));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Kill();

        rectTransform.DOAnchorPosX(originPos, 0.5f).SetUpdate(true);
        rectTransform.DOScale(1, 0.25f).SetUpdate(true);
        image.DOColor(originColor, 0.4f).SetUpdate(true);
    }

    private void Kill()
    {
        image.DOKill();
        rectTransform.DOKill();
    }
}
