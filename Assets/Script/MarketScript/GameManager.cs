using UnityEngine;
using UnityEngine.UI;
using TMPro;  // For TextMeshPro support

public class GameManager : MonoBehaviour
{
    [Header("Game Over Panel")]
    public GameObject gameOverPanel;  // The Game Over panel that will be shown

    [Header("Panels to Hide")]
    public GameObject[] panelsToClose;  // All other panels that need to be hidden when game over

    [Header("Player Health")]
    public int playerLives = 3;  // Starting number of lives

    [Header("Player Hearts")]
    public Image[] playerHearts;  // UI elements representing player lives (hearts)

    void Start()
    {
        UpdateHearts();  // Update the UI to reflect the starting number of hearts
    }

    // Call this method to deduct 1 heart when player loses a life
    public void DeductHeart()
    {
        playerLives--;
        UpdateHearts();  // Update the UI to show the remaining lives

        if (playerLives <= 0)
        {
            // Game over, show the Game Over panel
            ShowGameOverPanel();
        }
    }

    // Update the heart images based on the number of lives
    void UpdateHearts()
    {
        // Ensure the hearts UI reflects the current number of lives
        for (int i = 0; i < playerHearts.Length; i++)
        {
            playerHearts[i].enabled = i < playerLives;  // Show or hide hearts based on lives
        }
    }

    // Show the Game Over panel and hide all other panels
    void ShowGameOverPanel()
    {
        // Hide all other panels
        foreach (var panel in panelsToClose)
        {
            panel.SetActive(false);  // Disable the other panels
        }

        // Show the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);  // Activate the Game Over panel
        }
    }
}
