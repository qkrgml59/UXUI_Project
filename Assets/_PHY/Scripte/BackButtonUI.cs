using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButtonUI : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 0.5f;

    private bool isLoading;

    private void Start()
    {
        if (fadeImage == null)
            return;

        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        fadeImage.DOFade(0f, fadeDuration);
    }

    public void BackToMain()
    {
        if (isLoading)
            return;

        isLoading = true;

        if (fadeImage == null)
        {
            SceneManager.LoadScene("MainScene");
            return;
        }

        fadeImage.DOFade(1f, fadeDuration)
            .OnComplete(() =>
            {
                SceneManager.LoadScene("MainScene");
            });
    }
}