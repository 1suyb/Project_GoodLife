using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : ScriptableObject
{
    public ItemData[] inventoryDatas = new ItemData[30];

    private int m_gold = 0;
    public int gold
    {
        get => m_gold;
        set
        {
            m_gold += value;
        }
    }
    public int InputItem(ItemData item)
    {
        for(int i = 0; i < inventoryDatas.Length; i++)
        {
            if (inventoryDatas[i].IsEqual(item))
            {
                inventoryDatas[i].itemCount += item.itemCount;
                return i;
            }
            else if(inventoryDatas[i] == null)
            {
                inventoryDatas[i] = item.Clone();
                return i;
            }
        }
        return -1;
    }
    public int GetItem(ItemData item)
    {
        return -1;
    }

    public void GetItem()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
