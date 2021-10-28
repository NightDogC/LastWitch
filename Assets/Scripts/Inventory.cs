using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public static int[] invtArr;
    
    public static void InitInventory()
    {
        Debug.Log(IngredientManager.Ingreds.Count.ToString() + " kinds of ingredients found.");
        invtArr = new int[IngredientManager.Ingreds.Count];
    }

    public static void PutIngreds(int id, int amount = 1)
    {
        invtArr[id] += amount;
    }
    public static void TakeIngreds(int id, int amount = 1)
    {
        invtArr[id] -= amount;
        if (invtArr[id] < 0)
        {
            invtArr[id] = 0;
        }
    }
}
