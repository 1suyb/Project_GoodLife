using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHelper
{
    public static T[] Deserialize<T>(string datatype)
    {
        string path = Application.dataPath + "/DataTables/" + datatype + ".json";
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

public static class JsonUtil
{
    private static string ConvertType(DataType datatype)
    {
        string filename;
        switch(datatype){
          case DataType.Item : 
                filename = "ItemTable";
                break;
            default :
                filename = "";
                break;
        }
        return filename;
    }
    
    public static List<Item> ItemDeserialize(DataType datatype)
    {
        StringItem[] t = JsonHelper.Deserialize<StringItem>(ConvertType(datatype));
        List<Item> l = StringItem.Convert(t);
        return l;
    }

}
