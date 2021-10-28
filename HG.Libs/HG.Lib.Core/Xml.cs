using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace HG.Libs {
    public class Xml {
        public static List<T> DeserializeList<T>( string path ) where T : new()
        {
            XmlDocument ingXml = new XmlDocument();
            ingXml.Load( path );
            XmlNode xmlNode = ingXml.DocumentElement;
            XmlNodeList xnl = xmlNode.ChildNodes;
            List<T> l = new List<T>();
            foreach ( XmlNode e in xnl ) {
                T obj = new T();
                Type t = obj.GetType();
                FieldInfo[] fields = t.GetFields();
                foreach ( FieldInfo f in fields ) {
                    string val = e.Attributes[f.Name].Value;
                    if ( f.FieldType == typeof( int ) ) {
                        f.SetValue( obj, int.Parse( val ) );
                    } else if ( f.FieldType == typeof( double ) ) {
                        f.SetValue( obj, double.Parse( val ) );
                    } else if ( f.FieldType == typeof( string ) ) {
                        f.SetValue( obj, val );
                    }
                }
                l.Add( obj );
            }
            return l;
        }
    }
}
