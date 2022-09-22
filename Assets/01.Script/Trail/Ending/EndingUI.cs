using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class EndingUI : MonoBehaviour
{
    [SerializeField] private RectTransform upImage;
    [SerializeField] private RectTransform downImage;
    [SerializeField] private CanvasGroup canvasGroup;

    private float canvasAlpha = 0;
    
    public void Close()
    {
        upImage.GetChild(0).gameObject.SetActive(false);
        downImage.GetChild(0).gameObject.SetActive(false);
        downImage.GetChild(1).gameObject.SetActive(false);
        upImage.DOScaleY(5, 1);
        downImage.DOScaleY(5, 1);
        StartCoroutine(Ending());
    }
    public void Update()
    {
        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, canvasAlpha, Time.deltaTime);
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(2);
        canvasGroup.gameObject.SetActive(true);
        canvasAlpha = 1;
        JsonManager.Data.curStationIndex = 0;
        JsonManager.Data.hasSawTrail = false;
        JsonManager.Data.openBox = new List<string>();
        JsonManager.Data.inventory = new List<InventoryItemData>();
        JsonManager.Save();
    }
}
