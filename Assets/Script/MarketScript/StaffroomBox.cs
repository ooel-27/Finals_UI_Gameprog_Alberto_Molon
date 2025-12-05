using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaffroomBox : MonoBehaviour
{
    public TMP_Text stockText;  // Display the current stock text
    public Button boxButton;    // Button to grab items from Staffroom

    public int maxStock = 30;
    public int currentStock = 30;  // The starting stock for the Staffroom

    void Start()
    {
        UpdateStockText();
    }

    // Deduct stock from the Staffroom box and return how many were taken
    public int TakeItems(int amount)
    {
        // Ensure we don't take more than available stock
        int taken = Mathf.Min(amount, currentStock);
        currentStock -= taken;
        UpdateStockText();
        return taken;  // Return the number of items taken
    }

    // Restock the box to its maximum amount (manual reset if needed)
    public void RestockBox()
    {
        currentStock = maxStock;
        UpdateStockText();
    }

    // Update the stock text display
    void UpdateStockText()
    {
        if (stockText != null)
            stockText.text = currentStock + "/" + maxStock;
    }
}
