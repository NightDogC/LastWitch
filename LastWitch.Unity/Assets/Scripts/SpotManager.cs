using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//采用序列化方法，Unity中Spot挂载脚本后，在Inspector里编辑该地图信息
public class SpotManager : MonoBehaviour
{
    public IngredsInSpot[] ingredslist;
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
    public int ingredsId;
    public amountAndProb[] amountAndProb;
}



