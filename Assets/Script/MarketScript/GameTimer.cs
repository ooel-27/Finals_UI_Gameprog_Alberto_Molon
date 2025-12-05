using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Import for scene management

public class GameTimer : MonoBehaviour
{
    [Header("Timer Display")]
    public TMP_Text timeDisplay; // TextMeshPro to show the time

    [Header("Game Time Settings")]
    public int startHour = 8;    // Start at 8 AM (8:00)
    public int endHour = 18;     // End at 6 PM (18:00)
    private int currentHour;
    private int currentMinute;

    private float timer = 0f; // Timer to track real time passing

    [Header("Time Speed Multiplier")]
    public float timeSpeed = 5f;  // Set this to speed up the in-game time (e.g., 5 = 5 minutes per second)

    void Start()
    {
        currentHour = startHour;
        currentMinute = 0;
        UpdateTimeDisplay();
    }

    void Update()
    {
        // Increment timer based on timeSpeed multiplier
        timer += Time.deltaTime * timeSpeed;

        // Check if 1 in-game minute has passed (adjusted for time speed)
        if (timer >= 1f)  // 1 second in real time = `timeSpeed` in game minutes
        {
            timer = 0f; // Reset the timer

            // Increment in-game minute and handle the transition
            currentMinute++;
            if (currentMinute == 60)  // Every 60 minutes, increase the hour
            {
                currentMinute = 0;
                currentHour++;

                // Handle the transition to 12 PM correctly
                if (currentHour == 12)
                {
                    currentHour = 12;  // It will now show 12:00 correctly for PM
                }

                // Check if the time has exceeded 6 PM (game over or stop the clock)
                if (currentHour == endHour)
                {
                    EndOfDay();
                }
            }

            // Update time display in the UI
            UpdateTimeDisplay();
        }
    }

    void UpdateTimeDisplay()
    {
        // Handle 12-hour format display: Show "12:00" instead of "00:00"
        string hourDisplay = currentHour > 12 ? (currentHour - 12).ToString() : currentHour.ToString();
        string ampm = currentHour >= 12 ? "PM" : "AM";

        // Format time to show "8:00", "9:00", ..., "12:00"
        timeDisplay.text = $"{hourDisplay}:{currentMinute:00} {ampm}";
    }

    void EndOfDay()
    {
        // Actions when time reaches 6 PM
        Debug.Log("End of Day! It's now 6 PM.");

        // Transition to the NightScene
        SceneManager.LoadScene("NightScene");  // Make sure "NightScene" is the correct scene name
    }
}
