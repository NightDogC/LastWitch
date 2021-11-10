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
    public int ingredsId;
    public amountAndProb[] amountAndProb;
}




