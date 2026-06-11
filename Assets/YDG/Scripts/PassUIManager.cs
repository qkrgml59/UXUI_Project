using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PassUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public CanvasGroup leftMenuPanel;
    public CanvasGroup mainContentPanel;
    public RectTransform characterPanel;

    [Header("Quest List")]
    public List<CanvasGroup> questItems;

    void Start()
    {
        InitUI();
        PlayEnterAnimation();
    }

    private void InitUI()
    {
        leftMenuPanel.alpha = 0;
        mainContentPanel.alpha = 0;

        characterPanel.anchoredPosition = new Vector2(710, 0);

        foreach (var item in questItems)
        {
            item.alpha = 0;
            item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50);
        }
    }

    public void PlayEnterAnimation()
    {
        leftMenuPanel.DOFade(1f, 0.4f).SetEase(Ease.OutQuad);
        mainContentPanel.DOFade(1f, 0.4f).SetEase(Ease.OutQuad);

        characterPanel.DOAnchorPos(Vector2.zero, 0.6f).SetEase(Ease.OutBack);

        Sequence listSequence = DOTween.Sequence();

        for (int i = 0; i < questItems.Count; i++)
        {
            RectTransform itemRect = questItems[i].GetComponent<RectTransform>();

            listSequence.Append(itemRect.DOAnchorPosY(0, 0.3f).SetEase(Ease.OutCubic))
                        .Join(questItems[i].DOFade(1f, 0.3f))
                        .AppendInterval(0.08f);
        }
    }

    public void OnClickActionButton(RectTransform buttonRect)
    {
        buttonRect.DOPunchScale(new Vector3(-0.1f, -0.1f, 0), 0.2f, 5, 1);
    }
}
