
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Assign this to your SETTINGS panel in Inspector
    public GameObject settingsPanel;

    // Assign this to your MAIN MENU panel in Inspector (optional)
    public GameObject mainMenuPanel;

    // Start Game
    public void PlayGame()
    {
        Debug.Log("Play button clicked!");
        SceneManager.LoadScene("MarketScene");
    }

    // Open Settings Panel
    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    // Back to Main Menu Panel
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // Quit Game
    public void QuitGame()
    {
        Debug.Log("Quit button clicked!");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
