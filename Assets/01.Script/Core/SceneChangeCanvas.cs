using DG.Tweening;
using System;
using UnityEngine;

public class SceneChangeCanvas : MonoBehaviour
{
    static CanvasGroup group;
    static Sequence loadingSeq = null;
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        group = GetComponent<CanvasGroup>();
    }
    public static void Active(Action callbackAction = null)
    {
        Time.timeScale = 1.0f;
        loadingSeq = DOTween.Sequence();
        loadingSeq.Append(DOTween.To(() => group.alpha, x => group.alpha = x, 1, 0.5f)).SetUpdate(false);
        loadingSeq.AppendInterval(1.5f).SetUpdate(false);
        loadingSeq.AppendCallback(() => { callbackAction?.Invoke(); });
    }
    public static void DeActive(Action callbackAction = null)
    {
        loadingSeq = DOTween.Sequence();
        loadingSeq.Append(DOTween.To(() => group.alpha, x => group.alpha = x, 0, 0.5f)).SetUpdate(false);
        loadingSeq.AppendCallback(() => { callbackAction?.Invoke(); });
    }
}
