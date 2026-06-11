using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [Header("페이드 이미지")]
    [SerializeField] private Image fadeImage;

    [Header("페이드 시간")]
    [SerializeField] private float fadeDuration = 0.5f;

    private bool isLoading;

    private void Start()
    {
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        fadeImage.DOFade(0f, fadeDuration);
    }

    public void OpenMail()
    {
        //나중에이름바꾸시긔
        LoadScene("MailScene");
    }

    public void OpenPass()
    {
        LoadScene("Pass");
    }

    public void OpenShop()
    {
        LoadScene("ShopScene");
    }

    private void LoadScene(string sceneName)
    {
        if (isLoading)
            return;

        isLoading = true;

        fadeImage.DOFade(1f, fadeDuration)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(sceneName);
            });
    }
}
