using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public static class JsonHelper2
{
    public static T[] Deserialize<T>(string datatype) where T : Data
    {
        //string path = Application.dataPath + "/DataTables/" + datatype+".json";
        //string jsontext = System.IO.File.ReadAllText(path);
        string jsontext = @"
[
    {
        ""ID"" : 12,
        ""Name"" : ""hi""
    },
    {
        ""ID"" : 13,
        ""Name"" : ""Hello""
    }
]";
        jsontext = "{ \n \"Items\" : " + jsontext + "}";
        Wrapper<T> w = JsonUtility.FromJson<Wrapper<T>>(jsontext);
       // Debug.Log(jsontext);
        //Debug.Log(w.Items[0].id);
        return w.Items;
    }
    /*
    public static Dictionary<int,T> MakeDictionary<T>(T[] array) where T : Data
    {
        Dictionary<int, T> dic = new Dictionary<int, T>();
        foreach(T item in array)
        {
            dic.Add(item.id, item);
        }
        return dic;
    }*/

    [System.Serializable]
    private struct Wrapper<T>
    {
        public T[] Items;
    }
}
public class TestData
{
    public string ID;
    public string Name;

    public List<TestData1> Deserialize()
    {
        string jsontext = @"
[
    {
        ""ID"" : 12,
        ""Name"" : ""hi""
    },
    {
        ""ID"" : 13,
        ""Name"" : ""Hello""
    }
]";
        jsontext = "{ \n \"Items\" : " + jsontext + "}";
        Wrapper<TestData> w = JsonUtility.FromJson<Wrapper<TestData>>(jsontext);
        List<TestData1> t = new List<TestData1>();
        foreach(TestData item in w.Items)
        {
            t.Add(new TestData1(int.Parse(item.ID),item.Name));
        }
        return t;
    }
    
    
}
[System.Serializable]
public struct Wrapper<T>
{
    public T[] Items;
}
public class Data
{
    public int ID;
}
public class TestData1 : Data
{
    public string name;
    public TestData1(int id, string name)
    {
        this.ID = id;
        this.name = name;
    }
}