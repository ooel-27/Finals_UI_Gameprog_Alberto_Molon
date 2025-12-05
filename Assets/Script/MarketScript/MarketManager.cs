using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public Button drinkBoxButton;
    public Button dessertBoxButton;
    public Button mealBoxButton;

    // Optional: sprites for the full boxes
    public Sprite drinkFullSprite;
    public Sprite dessertFullSprite;
    public Sprite mealFullSprite;

    // Optional: sprites for empty boxes
    public Sprite emptyBoxSprite;

    // ---------------------------------------------------

    // Call this when player wins RPS
    public void RestockMarket()
    {
        Debug.Log("Restocking all boxes...");

        // Drink box
        if (drinkBoxButton != null && drinkFullSprite != null)
            drinkBoxButton.image.sprite = drinkFullSprite;

        // Dessert box
        if (dessertBoxButton != null && dessertFullSprite != null)
            dessertBoxButton.image.sprite = dessertFullSprite;

        // Meal box
        if (mealBoxButton != null && mealFullSprite != null)
            mealBoxButton.image.sprite = mealFullSprite;
    }

    // ---------------------------------------------------

    // You can call this when boxes are consumed to empty them
    public void EmptyBox(string boxType)
    {
        if (boxType == "drink" && drinkBoxButton != null)
            drinkBoxButton.image.sprite = emptyBoxSprite;

        else if (boxType == "dessert" && dessertBoxButton != null)
            dessertBoxButton.image.sprite = emptyBoxSprite;

        else if (boxType == "meal" && mealBoxButton != null)
            mealBoxButton.image.sprite = emptyBoxSprite;
    }
}
