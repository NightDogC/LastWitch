using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Reflection;
using Newtonsoft.Json;
using HG.Libs;
using System;
using System.IO;

public class IngredientInfo {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quality { get; set; }
    public int BaseScore { get; set; }
    public string Description { get; set; }
}
public class Ingredient {
    IngredientInfo Info;
    public long PickTime { get; set; }
    public int Count { get; set; } = 0;
    public void Put()
    {
        Count++;
    }
    public void Take()
    {
        Count = Count - 1 <= 0 ? 0 : Count - 1;
    }
    public Ingredient( int Count, long Picktime = -1 )
    {
        this.PickTime = PickTime == -1 ? DateTime.Now.Ticks : PickTime;
        this.Count = Count;
    }
}

public class IngredientInfoManager {
    public enum Load {
        XML,
        JSON,
        EXCEL
    }
    private const string mJsonPath = "Configs/Ingredients.json";
    private const string mExcelPath = "Excels/IngredientInfos.xlsx";

    public IngredientInfoManager( Load load = Load.EXCEL )
    {
        switch ( load ) {
            case Load.XML:
                // IngredientInfo = LoadXml<>
                break;
            case Load.JSON:
                IngredInfos = LoadJson();
                break;
            case Load.EXCEL:
                IngredInfos = LoadExcel();
                break;
            default:
                break;
        }
    }
    public List<IngredientInfo> IngredInfos { get; set; } = new List<IngredientInfo>();
    public List<IngredientInfo> LoadExcel( string path = mExcelPath )
    {
        return Excel.DeserializeList<IngredientInfo>( path, true );
    }
    public List<IngredientInfo> LoadJson()
    {
        var jstr = File.ReadAllText( mJsonPath );
        return JsonConvert.DeserializeObject<List<IngredientInfo>>( jstr );
    }
    public void SaveJson()
    {
        var jstr = JsonConvert.SerializeObject( IngredInfos );
        File.WriteAllText( mJsonPath, jstr );
    }
}
