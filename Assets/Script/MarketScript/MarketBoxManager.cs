using UnityEngine;
using UnityEngine.UI;

public class MarketBoxManager : MonoBehaviour
{
    public Button drinkBox;
    public Button dessertBox;
    public Button mealBox;

    public Sprite fullSprite;
    public Sprite emptySprite;

    // Called when player wins RPS
    public void RestockAll()
    {
        SetFull(drinkBox);
        SetFull(dessertBox);
        SetFull(mealBox);

        Debug.Log("All boxes restocked!");
    }

    // Make box empty after staff uses it
    public void UseBox(string type)
    {
        if (type == "drink") SetEmpty(drinkBox);
        if (type == "dessert") SetEmpty(dessertBox);
        if (type == "meal") SetEmpty(mealBox);
    }

    void SetFull(Button box)
    {
        box.image.sprite = fullSprite;
        box.interactable = true;
    }

    void SetEmpty(Button box)
    {
        box.image.sprite = emptySprite;
        box.interactable = false;
    }
}
