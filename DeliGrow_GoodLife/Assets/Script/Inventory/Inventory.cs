using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory",menuName = "Scriptable/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    public InventoryUI _inventoryUI;
    [SerializeField]
    private ItemData[] _inventoryDatas;

    public ItemData[] inventoryDatas
    {
        get => _inventoryDatas;
    }

    public ItemData tmp;
    

    
    [SerializeField]
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
            Debug.Log("아이템서치 성공");
            inventoryDatas[index].itemCount += item.itemCount;
            return _inventoryUI.PutInSlot(index);
        }
        index = SearchNull();
        if(index != -1)
        {
            Debug.Log("널슬롯 서치 성공");
            inventoryDatas[index] = item;
            return _inventoryUI.PutInSlot(index);
        }
        Debug.Log("공간 서치 실패");
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
        _inventoryUI.UpdateGold();
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
            _inventoryUI.UpdateGold();
            return true;
        }
    }
    public void UseItem()
    {

    }
    /*
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
    }*/

    public void Swap(int index1, int index2)
    {
        tmp = _inventoryDatas[index1].Clone();
        _inventoryDatas[index1] = _inventoryDatas[index2].Clone();
        _inventoryDatas[index2] = tmp.Clone();
    }

    private int SearchItem(ItemData item)
    {
        for (int i = 0; i < inventoryDatas.Length; i++)
        {
            if (inventoryDatas[i].id != 0)
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
            if (inventoryDatas[i].id != 0)
            {
                Debug.Log("널아닌뎁쇼..");
            }
            else
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
