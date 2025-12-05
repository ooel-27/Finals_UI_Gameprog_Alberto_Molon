using UnityEngine;
using DG.Tweening;

public class MainMenuAnimator : MonoBehaviour
{
    [Header("UI Elements")]
    public RectTransform title;
    public RectTransform[] buttons;

    [Header("Animation Settings")]
    public float titleSlideDuration = 1f;
    public float buttonSlideDuration = 0.5f;
    public float buttonDelay = 0.2f;

    void Start()
    {
        AnimateMenu();
    }

    void AnimateMenu()
    {
        // Slide title from top
        Vector3 titleStartPos = title.anchoredPosition;
        title.anchoredPosition = new Vector3(titleStartPos.x, titleStartPos.y + 500f, titleStartPos.z);
        title.DOAnchorPosY(titleStartPos.y, titleSlideDuration).SetEase(Ease.OutBounce);

        // Slide buttons from right
        for (int i = 0; i < buttons.Length; i++)
        {
            RectTransform btn = buttons[i];
            Vector3 btnStartPos = btn.anchoredPosition;
            btn.anchoredPosition = new Vector3(btnStartPos.x + 800f, btnStartPos.y, btnStartPos.z);

            // Animate with delay
            btn.DOAnchorPosX(btnStartPos.x, buttonSlideDuration)
               .SetEase(Ease.OutBack)
               .SetDelay(buttonDelay * i);
        }
    }
}
