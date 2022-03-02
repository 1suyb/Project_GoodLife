using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public static class JsonUtil
{
    public static List<ItemTable> LoadData(Type type)
    {

    }
    public static List<ItemTable> Deserialize(string datatype)
    {
        StringItemData[] t = JsonHelper.Deserialize<StringItemData>(datatype);
        List<ItemTable> l = StringItemData.Convert(t);
        return l;
    }
}

public static class JsonHelper
{
    public static T[] Deserialize<T>(string datatype)
    {
        string path = Application.dataPath + "/DataTables/" + datatype+".json";
        string jsontext = System.IO.File.ReadAllText(path);
        jsontext = "{ \n \"Items\" : " + jsontext + "}";

        Wrapper<T> w = JsonUtility.FromJson<Wrapper<T>>(jsontext);
        return w.Items;
    }

    [System.Serializable]
    private struct Wrapper<T>
    {
        public T[] Items;
    }
}

public class StringItemData
{
    public string ID;
    public string Name;
    
    public static List<ItemTable> Convert(StringItemData[] table)
    {
        List<ItemTable> t = new List<ItemTable>();
        foreach(StringItemData item in table)
        {
            t.Add(new ItemTable(item.ID, item.Name));
        }
        return t;   
    }
}
public class Table
{
    public int ID;
}

public class ItemTable :Table
{
    public string Name;
    public ItemTable(string ID,string Name)
    {
        this.ID = int.Parse(ID);
        this.Name = Name;
    }
}*/