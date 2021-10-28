using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    void Awake()
    {
        IngredientInfoManager im = new IngredientInfoManager();
        Debug.Log( im.IngredInfos.Count.ToString() + " kinds of ingredients found." );
    }
}
