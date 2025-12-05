using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShelfPanel : MonoBehaviour
{
    [Header("Shelf Visuals")]
    public Image[] itemImages; // 9 images showing items on the shelf
    public TMP_Text stockText; // Shows X/30 stock

    [Header("Staffroom Source")]
    public StaffroomBox staffroomBox; // Reference to the StaffroomBox to grab items from

    [Header("Refill Button")]
    public Button refillButton; // Button to trigger shelf refill

    [Header("Shelf Settings")]
    public int maxShelfStock = 30;  // Max stock per shelf
    private int currentShelfStock = 0; // Current stock in shelf

    [Header("Game Over Panel")]
    public GameObject gameOverPanel;  // The Game Over panel that you will display

    [Header("Other Panels to Close")]
    public GameObject[] panelsToClose; // Array to hold all the panels to deactivate when the game ends

    [Header("Player Hearts")]
    private int playerLives = 3;

    void Start()
    {
        UpdateShelfText();  // Initial update of stock text
        refillButton.onClick.AddListener(RestockShelf);  // Adding listener to refill button
        ClearShelf();  // Clear the shelf initially (optional)
    }

    // This function will refill the shelf from the StaffroomBox, but now it's manual
    public void RestockShelf()
    {
        if (staffroomBox == null)
        {
            Debug.LogWarning("No Staffroom box assigned!");
            return;
        }

        int availableSpace = maxShelfStock - currentShelfStock;

        if (availableSpace <= 0)
        {
            Debug.Log("Shelf already full!");
            return;
        }

        // Manually take stock from Staffroom, only refill up to 30
        int takenFromStaffroom = Mathf.Min(availableSpace, staffroomBox.currentStock);

        if (takenFromStaffroom <= 0)
        {
            Debug.Log("Nothing to restock from Staffroom!");
            return;
        }

        // Deduct taken items from Staffroom
        staffroomBox.TakeItems(takenFromStaffroom); // This reduces Staffroom stock

        currentShelfStock += takenFromStaffroom;  // Add items manually to the shelf
        UpdateShelfText();  // Update stock text after adding items

        // Update visual images to match the stock level
        UpdateShelfVisuals();

        Debug.Log($"{takenFromStaffroom} items added to shelf. Shelf now: {currentShelfStock}/{maxShelfStock}");
    }

    // Update the visual images of the shelf
    void UpdateShelfVisuals()
    {
        for (int i = 0; i < itemImages.Length; i++)
        {
            // Only enable images for items that are in stock
            itemImages[i].enabled = i < currentShelfStock;
        }
    }

    // Clear shelf visuals and set stock to 0
    public void ClearShelf()
    {
        currentShelfStock = 0;
        UpdateShelfText();
        foreach (var img in itemImages)
            img.enabled = false;
    }

    // Update the text that shows current stock
    void UpdateShelfText()
    {
        if (stockText != null)
            stockText.text = currentShelfStock + "/" + maxShelfStock;
    }

    // Call this when a player buys/takes an item from the shelf
    public bool TakeItem(int amount = 1)
    {
        if (currentShelfStock <= 0)
        {
            Debug.Log("Shelf empty!");
            return false; // Cannot take item if shelf is empty
        }

        int taken = Mathf.Min(amount, currentShelfStock);
        currentShelfStock -= taken;

        // Update shelf visuals after taking items
        UpdateShelfVisuals();

        UpdateShelfText();

        Debug.Log($"Player took {taken} items from shelf. Remaining: {currentShelfStock}/{maxShelfStock}");
        return true;
    }

    // Method to reduce hearts and check if the game is over
    public void DeductHeart()
    {
        playerLives--;
        Debug.Log("Heart lost! Player lives: " + playerLives); // Debug message to check if this is called

        UpdateHearts();

        if (playerLives <= 0)
        {
            Debug.Log("GAME OVER!"); // Debug message to confirm Game Over
            ShowGameOverPanel(); // Show the Game Over panel
        }
    }

    // Update hearts UI when hearts change
    void UpdateHearts()
    {
        // Here, you can update the hearts UI (e.g., using images) based on the number of lives remaining
    }

    // Method to show the Game Over panel and hide other panels
    void ShowGameOverPanel()
    {
        // Hide all other panels
        foreach (var panel in panelsToClose)
        {
            panel.SetActive(false); // Disable other panels
        }

        // Display the Game Over panel
        if (gameOverPanel != null)
        {
            Debug.Log("Showing Game Over Panel...");
            gameOverPanel.SetActive(true);  // Display the Game Over panel when lives are 0
        }
    }
}
