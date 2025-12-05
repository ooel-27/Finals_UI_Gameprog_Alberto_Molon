using TMPro;
using UnityEngine;

public class MarketInventory : MonoBehaviour
{
    public int drinksCount = 0;
    public int dessertsCount = 0;
    public int mealsCount = 0;

    public TMP_Text drinksText;
    public TMP_Text dessertsText;
    public TMP_Text mealsText;

    public void AddPrize(string category, int amount)
    {
        if (category == "drinks")
            drinksCount += amount;

        else if (category == "dessert")
            dessertsCount += amount;

        else if (category == "meal")
            mealsCount += amount;

        Debug.Log("Added " + amount + " to " + category);
        UpdateInventoryUI();
    }

    public void AddRandomGoods(int amount)
    {
        string[] categories = { "drinks", "dessert", "meal" };

        for (int i = 0; i < amount; i++)
        {
            string randomCategory = categories[Random.Range(0, categories.Length)];

            AddPrize(randomCategory, 1);
        }

        Debug.Log("Added " + amount + " random goods.");
    }


    // Updates the UI elements after a prize is added
    void UpdateInventoryUI()
    {
        if (drinksText != null) drinksText.text = "Drinks: " + drinksCount;
        if (dessertsText != null) dessertsText.text = "Desserts: " + dessertsCount;
        if (mealsText != null) mealsText.text = "Meals: " + mealsCount;
    }
}
