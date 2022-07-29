using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color activeColor = Color.white;
    [SerializeField] private float activeMoveValue;
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
        rectTransform.DOMoveX(originPos + activeMoveValue, 0.25f);
        image.DOColor(activeColor, 0.2f);
        PoolManager.Instance.Pop(PoolType.Sound).GetComponent<AudioPoolObject>().Play(activeClip, Random.Range(0.9f, 1.1f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOMoveX(originPos, 0.5f);
        image.DOColor(originColor, 0.6f);
    }
}
