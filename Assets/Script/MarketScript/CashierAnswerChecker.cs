using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // To load the main menu or restart the game

public class CashierAnswerChecker : MonoBehaviour
{
    [Header("Calculator Display")]
    public TMP_Text numberShower; // Your calculator display text

    [Header("Order Texts (from CustomerOrderPanel)")]
    public TMP_Text drinksText;
    public TMP_Text dessertsText;
    public TMP_Text mealsText;

    [Header("Item Prices")]
    public int drinkPrice = 15;
    public int dessertPrice = 30;
    public int mealPrice = 60;

    [Header("Player Hearts")]
    public Image[] playerHearts;
    private int playerLives = 3;

    [Header("Submit Button")]
    public Button submitAnswerButton;

    [Header("Customer Order Generator")]
    public CustomerOrderGenerator customerOrderGenerator;

    [Header("Shelf Manager")]
    public ShelfManager shelfManager;

    [Header("Game Over Panel")]
    public GameObject gameOverPanel;  // The Game Over panel that you will display

    [Header("Retry Button")]
    public Button retryButton; // Button for retrying the game

    [Header("Main Menu Button")]
    public Button mainMenuButton; // Button to go back to the main menu

    [Header("Calculator Panel")]
    public GameObject calculatorPanel; // Reference to the calculator panel (this is what you want to hide)

    public GameManager gameManager;

    void Start()
    {
        if (submitAnswerButton != null)
            submitAnswerButton.onClick.AddListener(CheckAnswer);

        // Add listeners to the buttons
        if (retryButton != null)
            retryButton.onClick.AddListener(RetryGame);

        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);

        UpdateHearts();
    }

    int CalculateCorrectTotal()
    {
        int drinks = int.Parse(drinksText.text);
        int desserts = int.Parse(dessertsText.text);
        int meals = int.Parse(mealsText.text);

        return drinks * drinkPrice + desserts * dessertPrice + meals * mealPrice;
    }

    void CheckAnswer()
    {
        if (!int.TryParse(numberShower.text, out int playerAnswer))
        {
            Debug.Log("Invalid number entered!");
            return;
        }

        int correctTotal = CalculateCorrectTotal();

        if (playerAnswer == correctTotal)
        {
            Debug.Log("Correct! Hearts safe!");

            // Deduct items from shelves
            if (shelfManager != null)
                FulfillOrder();

            // Generate a new order
            if (customerOrderGenerator != null)
                customerOrderGenerator.GenerateNewOrder();
        }
        else
        {
            Debug.Log("Wrong! Lose 1 heart!");
            DeductHeart();
        }

        // Reset calculator display
        numberShower.text = "0";
    }

    void FulfillOrder()
    {
        int drinks = int.Parse(drinksText.text);
        int desserts = int.Parse(dessertsText.text);
        int meals = int.Parse(mealsText.text);

        bool success = shelfManager.ProcessOrder(drinks, desserts, meals);

        if (success)
            Debug.Log("Order fulfilled! Shelves updated.");
        else
            Debug.LogWarning("Order failed: Not enough stock on shelves!");
    }

    void DeductHeart()
    {
        playerLives--;
        UpdateHearts();

        if (playerLives <= 0)
        {
            Debug.Log("GAME OVER!");
            ShowGameOverPanel(); // Show the Game Over panel
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < playerHearts.Length; i++)
        {
            playerHearts[i].enabled = i < playerLives;
        }
    }

    void ShowGameOverPanel()
    {
        // Hide the Calculator Panel
        if (calculatorPanel != null)
        {
            calculatorPanel.SetActive(false); // Deactivate the calculator panel
        }

        // Show the Game Over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the Game Over panel
        }
    }

    // Retry the current game (reload the current scene)
    void RetryGame()
    {
        // Reset hearts and other game parameters
        playerLives = 3;
        UpdateHearts();

        // Hide Game Over panel and reset the game state
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        // Optionally, you can also reset the game here, like clearing orders, etc.
        // Restart the game (reload current scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Go to the main menu (or a different scene)
    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Replace "MainMenu" with your actual main menu scene name
    }
}
