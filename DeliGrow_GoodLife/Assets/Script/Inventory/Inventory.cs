using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
    [SerializeField]
    private InventoryUI _inventoryUI;

    private ItemData[] _inventoryDatas = new ItemData[30];
    public ItemData[] inventoryDatas
    {
        get => _inventoryDatas;
    }

    private ulong m_gold = 0;
    public ulong gold
    {
        get => m_gold;
    }

    

    public bool PutInItem(ItemData item)
    {
        int index = SearchItem(item);
        if (index != -1)
        {
            inventoryDatas[index] = item;
            return _inventoryUI.PutInSlot(index);
        }
        index = SearchNull();
        if(index != -1)
        {
            inventoryDatas[index] = item;
            return _inventoryUI.PutInSlot(index);
        }
        return false;
        
    }
    public void SortItem()
    {
        for (int i = 0; i < inventoryDatas.Length; i++)
        {
            for (int j = i; j < inventoryDatas.Length; j++)
            {
                if (inventoryDatas[i] > inventoryDatas[j])
                {
                    swap(ref inventoryDatas[i], ref inventoryDatas[j]);
                }
            }
        }
        _inventoryUI.Sort();
    }
    public bool TakeOutItem(ItemData item)
    {
        int index = SearchItem(item);
        int itemcount = item.itemCount;
        int datasitemcount = inventoryDatas[index].itemCount;
        if(index != -1)
        {
            if (datasitemcount < itemcount)
            {
                return false;
            }
            else if(datasitemcount > itemcount)
            {
                inventoryDatas[index].itemCount -= itemcount;
                return _inventoryUI.TakeOutItemAtSlot(index);
            }
            else
            {
                inventoryDatas[index] = null;
                return _inventoryUI.TakeOutItemAtSlot(index);
            }
        }
        return false;

        
    }


    public void AddGold(ulong gold)
    {
        if(m_gold+gold> 18000000000000000000)
        {
            m_gold = 18000000000000000000;
        }
        else
        {
            m_gold += gold;
        }
        _inventoryUI.UpdateGold(m_gold);
    }
    public bool SubGold(ulong gold)
    {
        if(m_gold > gold)
        {
            return false;
        }
        else
        {
            m_gold -= gold;
            _inventoryUI.UpdateGold(m_gold);
            return true;
        }
    }
    public void UseItem()
    {

    }

    private int PutItemInInventory(ItemData item)
    {
        if (item.itemCount < 0)
        {
            return -1;
        }
        for (int i = 0; i < inventoryDatas.Length; i++)
        {
            if (inventoryDatas[i] != null)
            {
                if (inventoryDatas[i].IsEqual(item))
                {
                    inventoryDatas[i].itemCount += item.itemCount;
                    return i;
                }
            }
        }
        for (int i = 0; i < inventoryDatas.Length; i++)
        {
            if (inventoryDatas[i] == null)
            {
                inventoryDatas[i] = item;
                return i;
            }
        }
        return -1;
    }

    private int SearchItem(ItemData item)
    {
        for (int i = 0; i < inventoryDatas.Length; i++)
        {
            if (inventoryDatas[i] != null)
            {
                if (inventoryDatas[i].IsEqual(item))
                {
                    return i;
                }
            }
        }
        return -1;
    }
    private int SearchNull()
    {
        for (int i = 0; i < inventoryDatas.Length; i++)
        {
            if (inventoryDatas[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    private static void swap(ref ItemData val1, ref ItemData val2)
    {
        ItemData tmp = val1;
        val1 = val2;
        val2 = tmp;
    }

}
