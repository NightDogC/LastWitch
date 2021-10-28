using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Reflection;
using Newtonsoft.Json;
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
    public void Put() { 
        Count++;
    }
    public void Take() { 
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
        JSON
    }
    private const string mJsonPath = "Config/Ingredients.json";
    public IngredientInfoManager( Load load = Load.JSON )
    {
        switch ( load ) {
            case Load.XML:
                // IngredientInfo = LoadXml<>
                break;
            case Load.JSON:
                IngredInfos = LoadJson();
                break;
            default:
                break;
        }
    }
    public List<IngredientInfo> IngredInfos { get; set; } = new List<IngredientInfo>();
    public List<IngredientInfo> LoadJson()
    {
        var jstr = File.ReadAllText( mJsonPath );
        return JsonConvert.DeserializeObject<List<IngredientInfo>>( jstr );
    }
    public void SaveJson() { 
        var jstr = JsonConvert.SerializeObject( IngredInfos );
        File.WriteAllText( mJsonPath, jstr  );
    }
    // 为什么要用泛型？
    public List<T> LoadXml<T>( string path ) where T : new()
    {
        XmlDocument ingXml = new XmlDocument();
        ingXml.Load( path );
        XmlNode xmlNode = ingXml.DocumentElement;
        XmlNodeList xnl = xmlNode.ChildNodes;
        List<T> list = new List<T>();
        foreach ( XmlNode e in xnl ) {
            T obj = new T();
            Type t = obj.GetType();
            FieldInfo[] fields = t.GetFields();
            foreach ( FieldInfo f in fields ) {
                string val = e.Attributes[f.Name].Value;
                if ( f.FieldType == typeof( int ) ) {
                    f.SetValue( obj, int.Parse( val ) );
                    Debug.Log( val + "has recorded!" );
                } else if ( f.FieldType == typeof( double ) ) {
                    f.SetValue( obj, double.Parse( val ) );
                    Debug.Log( val + "has recorded!" );
                } else if ( f.FieldType == typeof( string ) ) {
                    f.SetValue( obj, val );
                    Debug.Log( val + "has recorded!" );
                }
            }
            list.Add( obj );
        }
        return list;
    }
}
