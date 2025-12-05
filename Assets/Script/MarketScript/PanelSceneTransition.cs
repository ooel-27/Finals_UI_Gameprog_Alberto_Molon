using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PanelSceneTransition : MonoBehaviour
{
    [Header("Transition Settings")]
    public CanvasGroup fadePanel; // Assign your panel with CanvasGroup here
    public float fadeDuration = 1f;

    private void Start()
    {
        // Start panel fully transparent
        fadePanel.alpha = 0f;
        fadePanel.interactable = false;
        fadePanel.blocksRaycasts = false;
    }

    public void TransitionToScene(string sceneName)
    {
        // Enable the panel so it blocks input
        fadePanel.interactable = true;
        fadePanel.blocksRaycasts = true;

        // Fade in the whole panel
        fadePanel.DOFade(1f, fadeDuration).OnComplete(() =>
        {
            // Load new scene after fade
            SceneManager.LoadScene(sceneName);
        });
    }

    private void OnEnable()
    {
        // Optional: fade out panel on scene load
        if (fadePanel.alpha == 1f)
        {
            fadePanel.DOFade(0f, fadeDuration).OnComplete(() =>
            {
                fadePanel.interactable = false;
                fadePanel.blocksRaycasts = false;
            });
        }
    }
}
