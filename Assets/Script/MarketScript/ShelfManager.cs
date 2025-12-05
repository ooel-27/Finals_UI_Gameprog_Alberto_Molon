using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public ShelfPanel drinksShelf;
    public ShelfPanel dessertsShelf;
    public ShelfPanel mealsShelf;

    public bool ProcessOrder(int drinks, int desserts, int meals)
    {
        bool success = true;

        if (!drinksShelf.TakeItem(drinks)) success = false;
        if (!dessertsShelf.TakeItem(desserts)) success = false;
        if (!mealsShelf.TakeItem(meals)) success = false;

        if (!success)
            Debug.Log("Not enough stock to complete the order!");

        return success;
    }
}
