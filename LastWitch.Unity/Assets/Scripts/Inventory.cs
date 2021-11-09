using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    static public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public Inventory()
    {
        for (int i = 0; i < IngredientInfoManager.IngredInfos.Count; i++)
        {
            Ingredient ing = new Ingredient(IngredientInfoManager.IngredInfos[i], 0);
            Ingredients.Add(ing);
            Debug.Log(ing.Info.Name.ToString() + " has signed up to inventory.");
        }
    }
}
