using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    void Awoke()
    {
        IngredientManager.ingredients = IngredientManager.LoadXml<IngredientManager.Ingredient>();
    }
}
