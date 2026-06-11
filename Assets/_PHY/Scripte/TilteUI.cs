using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TilteUI : MonoBehaviour
{
    [Header("씬 이름")]
    [SerializeField] private string mainSceneName = "MainScene";

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

    public void OnClickStart()
    {
        if (isLoading)
            return;

        isLoading = true;

        fadeImage.DOFade(1f, fadeDuration)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(mainSceneName);
            });
    }

    public void OnClickQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}
