using DG.Tweening;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;

    [SerializeField] private RectTransform[] buttons;

    private void Start()
    {
        CloseAllPanels();
    }

    public void OpenShopPanel()
    {
        CloseAllPanels();
        ShopPanel.SetActive(true);
    }

    public void CloseAllPanels()
    {
        ShopPanel.SetActive(false);

    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }

    private void OnEnable()
    {
        ShowButtons();
    }

    private void ShowButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].localScale = Vector3.zero;

            buttons[i].DOScale(1f, 0.3f).SetEase(Ease.OutBack).SetDelay(i * 0.1f);
        }
    }
}