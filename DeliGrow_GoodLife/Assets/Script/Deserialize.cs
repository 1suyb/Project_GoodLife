using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deserialize : MonoBehaviour
{
    string Json =
@"{
    ""Members"" : [
        {
            ""ID"" : ""12"",
            ""Name"" : ""hi""
        },
        {
            ""ID"" : ""13"",
            ""Name"" : ""Hello""
        }
    ]
}";
    public void Deserilaize()
    {
        //Member[] member = JsonHelper.FromJson<Member>(Json);
        //Debug.Log(member[0].ID);
        Table table = JsonUtility.FromJson<Table>(Json);
        Debug.Log(table.Members[0].ID);
    }
}
[System.Serializable]
public class Table
{

    public List<Member> Members;
}
[System.Serializable]
public class Member
{
    public string ID;
    public string Name;
}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}