using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Inventory()
    {
        Debug.Log( IngredientManager.Ingreds.Count.ToString() + " kinds of ingredients found." );
        Debug.Log( IngredientManager.Ingreds );
    }
}
