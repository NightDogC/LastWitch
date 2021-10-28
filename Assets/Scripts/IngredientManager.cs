using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Reflection;
using Newtonsoft.Json;
using System;
using System.IO;

public class Ingredient {
    public int id { get; set; }
    public string name { get; set; }
    public int quality { get; set; }
    public int baseScore { get; set; }
    public string description { get; set; }
    public int Count { get; set; } = 0;
    public void Put() { 
        Count++;
    }
    public void Take() { 
        Count = Count - 1 <= 0 ? 0 : Count - 1;
    }
}

public static class IngredientManager {
    private const string mJsonPath = "Config/Ingredients.json";
    public static List<Ingredient> Ingreds { get; set; }
    public static List<Ingredient> LoadJson()
    {
        var jstr = File.ReadAllText( mJsonPath );
        return JsonConvert.DeserializeObject<List<Ingredient>>( jstr );
    }
    public static void SaveJson() { 
        var jstr = JsonConvert.SerializeObject( Ingreds );
        File.WriteAllText( mJsonPath, jstr  );
    }
    // 为什么要用泛型？
    public static List<T> LoadXml<T>() where T : new()
    {
        XmlDocument ingXml = new XmlDocument();
        ingXml.Load( "Config/Ingredients.xml" );
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
