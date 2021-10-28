using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Reflection;
using System;

public class IngredientManager
{
    public struct Ingredient
    {
        int id;
        string name;
        int quality;
        int baseScore;
        string text;
    }

    public static List<Ingredient> ingredients;

    public static List<T> LoadXml<T>() where T: new()
    {
        XmlDocument ingXml = new XmlDocument();
        ingXml.LoadXml("Config/Ingredients.xml");
        XmlNode xmlNode = ingXml.DocumentElement;
        XmlNodeList xnl = xmlNode.ChildNodes;
        List<T> list = new List<T>();
        foreach (XmlNode e in xnl)
        {
            T obj = new T();
            Type t = obj.GetType();
            FieldInfo[] fields = t.GetFields();
            foreach (var f in fields)
            {
                string val =  e.Attributes[f.Name].Value;
                if (f.FieldType == typeof(int))
                {
                    f.SetValue(obj, int.Parse(val));
                }
                else if (f.FieldType == typeof(double))
                {
                    f.SetValue(obj, double.Parse(val));
                }
                else if (f.FieldType == typeof(string))
                {
                    f.SetValue(obj, val);
                }
            }
            list.Add(obj);
        }
        return list;
    }
}
