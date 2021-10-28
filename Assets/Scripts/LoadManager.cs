using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    void Awake()
    {
        IngredientManager.ingreds = IngredientManager.LoadXml<Ingredient>();
        Inventory.InitInventory();
    }
}
