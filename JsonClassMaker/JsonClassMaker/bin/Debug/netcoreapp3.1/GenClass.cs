using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DataType
{
  Item = 1;
}



public class Table
{
    public int ID;
}

public class Item : Table
{
  public int ID;
  public string Korean;
  public byte Main_type;
  public byte Sub_type;
  public byte Grade;
  public int Option_value_1;
  public int Option_value_2;
  public int Option_id_1;
  public int Option_id_2;
  public int Cool_time;
    public Item(int ID, string Korean, byte Main_type, byte Sub_type, byte Grade, int Option_value_1, int Option_value_2, int Option_id_1, int Option_id_2, int Cool_time)
    {
      this.ID = ID;
      this.Korean = Korean;
      this.Main_type = Main_type;
      this.Sub_type = Sub_type;
      this.Grade = Grade;
      this.Option_value_1 = Option_value_1;
      this.Option_value_2 = Option_value_2;
      this.Option_id_1 = Option_id_1;
      this.Option_id_2 = Option_id_2;
      this.Cool_time = Cool_time;
    }
}

public class StringItem
{
  public string ID;
  public string Korean;
  public string Main_type;
  public string Sub_type;
  public string Grade;
  public string Option_value_1;
  public string Option_value_2;
  public string Option_id_1;
  public string Option_id_2;
  public string Cool_time;

    public static List<Item> Convert(StringItem[] table)
    {
        List<Item> t = new List<Item>();
        foreach (StirngItem item in table)
        {
            t.Add(new Item(ID, Korean, Main_type, Sub_type, Grade, Option_value_1, Option_value_2, Option_id_1, Option_id_2, Cool_time);
        }
        return t;
    }
}


