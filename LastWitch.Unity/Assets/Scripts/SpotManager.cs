using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������л�������Unity��Spot���ؽű�����Inspector��༭�õ�ͼ��Ϣ
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

//�����۽����ʣ�ʵ���Բ�ͬ���ʻ�ò�ͬ������ʳ�ģ�ע�������۽�������Ҫ�ﵽ1
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




