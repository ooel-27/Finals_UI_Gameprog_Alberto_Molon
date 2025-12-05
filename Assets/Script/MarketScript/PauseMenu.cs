using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;      // The pause panel
    public string mainMenuScene;    // Main menu scene name

    private bool isPaused = false;

    void Update()
    {
        // Press ESC to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;    // Stop game time
        isPaused = true;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;    // Resume game time
        isPaused = false;
    }

    public void OpenSettings()
    {
        // Add your settings code here
        Debug.Log("Settings opened!");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Make sure time resumes
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
