using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemGrid : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] private Image frameImage;
    [SerializeField] private Image profileImage;
    [SerializeField] private TextMeshProUGUI countTmp;

    [Header("Color")]
    [SerializeField] private Color activeColor = Color.white;
    [SerializeField] private Color deactiveColor = Color.white;

    public TextMeshProUGUI CountTmp { get { return countTmp; } }
    public int Count { get { return count; } set 
        { 
            count = value;
            countTmp.text = count == 1 ? "" : count.ToString();
        } 
    }

    private Action onMouseDownAction;
    private int count = 0;

    public void RegistAction(Action ac)
    {
        onMouseDownAction = ac;
    }

    public void Init(ItemDataSO data, int count = 0)
    {
        Count = count;
        profileImage.sprite = data.itemSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onMouseDownAction?.Invoke();
    }

    public void OnDestroy()
    {
        DOTween.Kill(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        frameImage.transform.DOScale(1.1f, 0.25f).SetUpdate(true);
        frameImage.DOColor(activeColor, 0.25f).SetUpdate(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        frameImage.transform.DOScale(1f, 0.25f).SetUpdate(true);
        frameImage.DOColor(deactiveColor, 0.25f).SetUpdate(true);
    }
}
