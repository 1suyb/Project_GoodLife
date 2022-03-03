using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonUtil
{
    private static string ConvertType(DataType datatype)
    {
        string filename;
        switch(datatype){
          case Item : 
                filename = ItemTable.json;
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
