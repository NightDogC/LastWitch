using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Reflection;
using System;

public class Ingredient
{
    public int id;
    public string name;
    public int quality;
    public int baseScore;
    public string description;
}

public class IngredientManager
{
    public static List<Ingredient> Ingreds { get; set; }

    public static List<T> LoadXml<T>() where T: new()
    {
        XmlDocument ingXml = new XmlDocument();
        ingXml.Load("Config/Ingredients.xml");
        XmlNode xmlNode = ingXml.DocumentElement;
        XmlNodeList xnl = xmlNode.ChildNodes;
        List<T> list = new List<T>();
        foreach (XmlNode e in xnl)
        {
            T obj = new T();
            Type t = obj.GetType();
            FieldInfo[] fields = t.GetFields();
            foreach (FieldInfo f in fields)
            {
                string val =  e.Attributes[f.Name].Value;
                if (f.FieldType == typeof(int))
                {
                    f.SetValue(obj, int.Parse(val));
                    Debug.Log(val + "has recorded!");
                }
                else if (f.FieldType == typeof(double))
                {
                    f.SetValue(obj, double.Parse(val));
                    Debug.Log(val + "has recorded!");
                }
                else if (f.FieldType == typeof(string))
                {
                    f.SetValue(obj, val);
                    Debug.Log(val + "has recorded!");
                }
            }
            list.Add(obj);
        }
        return list;
    }
}
