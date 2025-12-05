using UnityEngine;
using TMPro;

public class CustomerOrderGenerator : MonoBehaviour
{
    [Header("Order Texts")]
    public TMP_Text drinksText;
    public TMP_Text dessertsText;
    public TMP_Text mealsText;

    void Start()
    {
        GenerateNewOrder();
    }

    public void GenerateNewOrder()
    {
        drinksText.text = GetRandomQuantity().ToString();
        dessertsText.text = GetRandomQuantity().ToString();
        mealsText.text = GetRandomQuantity().ToString();
    }

    int GetRandomQuantity()
    {
        int rand = Random.Range(0, 100); // 0-99

        if (rand < 5) return Random.Range(8, 11);   // 5% chance for 8-10
        if (rand < 20) return Random.Range(5, 8);   // 15% chance for 5-7
        return Random.Range(0, 5);                  // 80% chance for 0-4
    }
}
