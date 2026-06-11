using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassUIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public CanvasGroup leftMenuPanel;
    public CanvasGroup mainContentPanel;
    public RectTransform characterPanel;

    [Header("Quest List")]
    public List<CanvasGroup> questItems;

    [Header("Progress Bar")]
    public Image progressBarFill; 
    private float currentProgress = 0f;

    private Vector2 characterTargetPos;

    void Start()
    {
        characterTargetPos = characterPanel.anchoredPosition;

        InitUI();
        PlayEnterAnimation();
    }

    private void InitUI()
    {
        leftMenuPanel.alpha = 0;
        mainContentPanel.alpha = 0;

        characterPanel.anchoredPosition = new Vector2(characterTargetPos.x + 800f, characterTargetPos.y);

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

        characterPanel.DOAnchorPos(characterTargetPos, 0.6f).SetEase(Ease.OutBack);

        Sequence listSequence = DOTween.Sequence();

        for (int i = 0; i < questItems.Count; i++)
        {
            RectTransform itemRect = questItems[i].GetComponent<RectTransform>();

            listSequence.Append(itemRect.DOAnchorPosY(0, 0.3f).SetEase(Ease.OutCubic))
                        .Join(questItems[i].DOFade(1f, 0.3f))
                        .AppendInterval(0.08f);
        }
    }

    public void OnClickRewardButton(CanvasGroup questItemCanvasGroup)
    {
        questItemCanvasGroup.interactable = false;
        questItemCanvasGroup.blocksRaycasts = false;

        questItemCanvasGroup.DOFade(0f, 0.3f);
        questItemCanvasGroup.transform.DOScale(Vector3.zero, 0.3f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                questItemCanvasGroup.gameObject.SetActive(false);
            });

        AddProgress(0.2f);
    }

    private void AddProgress(float amount)
    {
        currentProgress += amount;
        if (currentProgress > 1f) currentProgress = 1f;

        progressBarFill.DOFillAmount(currentProgress, 0.5f).SetEase(Ease.OutQuad);
    }
}
