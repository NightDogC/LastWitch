using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpotManager : MonoBehaviour
{

    public IngredsInSpot[] ingredslist;
}

[Serializable]
public struct amountAndProb
{
    public int amount;
    public double prob;
}

[Serializable]
public struct IngredsInSpot
{
    public int ingredsId;
    public amountAndProb[] amountAndProb;
}


