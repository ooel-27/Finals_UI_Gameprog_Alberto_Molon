using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // This function loads the game scene and resets progress
    public void RetryGame()
    {
        // Reset PlayerPrefs progress here
        PlayerPrefs.SetInt("Day", 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene("MarketScene");
    }

    // This function loads the main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // This function loads the game scene without resetting progress
    public void ContinueGame()
    {
        // Just load the same scene but do NOT reset PlayerPrefs
        SceneManager.LoadScene("MarketScene");
    }
}
