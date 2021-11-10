using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//采用序列化方法，Unity中Spot挂载脚本后，在Inspector里编辑该地图信息
public class SpotManager : MonoBehaviour
{
    public bool isTargetSpot = false;
    public IngredsInSpot[] ingredslist;
    public GameObject mask;
    public GatherResultUI resultUI;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.isTargetSpot == true)
        {
            isTargetSpot = false;
            resultUI.ShowResult();
        }
    }
}

//采用累进概率，实现以不同概率获得不同数量的食材，注意最后的累进概率需要达到1
[Serializable]
public struct amountAndProb
{
    public int amount;
    //accumulated probability
    public double accProb;
}

[Serializable]
public struct IngredsInSpot
{
    public int Id;
    public amountAndProb[] amountAndProb;
    public Ingredient Draw() {
        int amount = 0;
        double rand = UnityEngine.Random.Range( 0f, 1f );
        foreach ( var ap in amountAndProb ) {
            if ( rand < ap.accProb ) {
                amount = ap.amount;
                break;
            }
        }
        return new Ingredient( IngredientInfoManager.IngredInfos[Id], amount, DateTime.Now.Ticks );
    }
}




