using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class GameData
{
    public static GameData Data{ get; set; }
    public static GameData NewGame() { 
        return new GameData {
            StartTime = DateTime.Now.Ticks,
            Inventory = new Inventory()
        };
    }
    /// <summary>
    /// ����Ϸ��ʼʱ��
    /// </summary>
    public long StartTime { get; set; }
    /// <summary>
    /// ��һ�α���ʱ��ʱ��
    /// </summary>
    public long LastSaveTime { get; set; }
    public GameData( string path = "" )
    {
        if ( path == "" ) {
            return;
        }
    }
    public Inventory Inventory { get; set; }
    public long PlayedTime() { return LastSaveTime - StartTime; }
    public static void Load( string path ) {
        Data = new GameData( path );
    }
    public void Save( string path ) {
        GameData.Data.LastSaveTime = DateTime.Now.Ticks;
        var jstr = JsonConvert.SerializeObject( GameData.Data );
        File.WriteAllText( path, jstr );
    }
}
