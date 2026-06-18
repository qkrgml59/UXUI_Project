using UnityEngine;
using DG.Tweening;

public class UIHideToggle : MonoBehaviour
{
    [SerializeField] private CanvasGroup uiRoot;

    private bool isVisible = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleUI();
        }
    }

    private void ToggleUI()
    {
        isVisible = !isVisible;

        if (isVisible)
        {
            uiRoot.gameObject.SetActive(true);

            uiRoot.alpha = 0f;
            uiRoot.DOFade(1f, 0.3f);
        }
        else
        {
            uiRoot.DOFade(0f, 0.3f).OnComplete(() =>
                {
                    uiRoot.gameObject.SetActive(false);
                });
        }
    }
}