using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    void Awake()
    {
        // IngredientManager.Ingreds = IngredientManager.LoadXml<Ingredient>();
        IngredientManager.Ingreds = IngredientManager.LoadJson();
        Inventory inventory = new Inventory();
    }
}
