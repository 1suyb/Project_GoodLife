using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable/Inventory")]
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
            return InsertItem(item, index);
        }
        index = SearchNull();
        if (index != -1)
        {
            return InsertItem(item, index);
        }
        Debug.Log("공간 서치 실패");
        return false;

    }
    public bool InsertItem(ItemData item, int index)
    {
        if (index < 0)
        {
            return false;
        }
        if (_inventoryDatas[index].id == item.id)
        {
            _inventoryDatas[index].itemCount += item.itemCount;
        }
        else
        {
            _inventoryDatas[index] = item;
        }
        _inventoryUI.SlotUpdate(index);
        return true;
    }

    public void SortItem()
    {
        for(int i = 0; i < _inventoryDatas.Length; i++)
        {
            for(int j = i+1; j < _inventoryDatas.Length; j++)
            {
                if (_inventoryDatas[i] <= _inventoryDatas[j])
                {
                    Swap(i, j);
                }
            }
        }
        _inventoryUI.Sort();
    }
    public bool TakeOutItem(ItemData item)
    {
        int index = SearchItem(item);
        int itemcount = item.itemCount;
        int datasitemcount = _inventoryDatas[index].itemCount;
        if(index != -1)
        {
            if (datasitemcount < itemcount)
            {
                return false;
            }
            else if(datasitemcount > itemcount)
            {
                _inventoryDatas[index].itemCount -= itemcount;
                _inventoryUI.SlotUpdate(index);
                return true;
            }
            else
            {
                _inventoryDatas[index].id = 0;
                _inventoryDatas[index].itemCount = 0;
                _inventoryUI.SlotUpdate(index);
                return true;
            }
        }
        return false;
    }
    public bool DeleteItem(ItemData item, int index)
    {
        if (index < 0)
        {
            return false;
        }
        Debug.Log(_inventoryDatas[index].itemCount);
        Debug.Log(item.itemCount);
        if (_inventoryDatas[index].id == item.id)
        {
            if(_inventoryDatas[index].itemCount>item.itemCount)
            {
                
                _inventoryDatas[index].itemCount -= item.itemCount;
                _inventoryUI.SlotUpdate(index);
                return true;
            }
            else if(_inventoryDatas[index].itemCount == item.itemCount)
            {
                _inventoryDatas[index].id = 0;
                _inventoryUI.SlotUpdate(index);
                return true;
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

    private int SearchItem(ItemData item)
    {
        for (int i = 0; i < inventoryDatas.Length; i++)
        {
            if (inventoryDatas[i].id == item.id)
            {
                return i;
            }
        }
        return -1;
    }

    private int SearchNull()
    {
        for (int i = 0; i < inventoryDatas.Length; i++)
        {
            if (inventoryDatas[i].id == 0)
            {
                return i;
            }

        }
        return -1;
    }

    private static void Swap(ref ItemData val1, ref ItemData val2)
    {

        ItemData tmp = val1;
        val1 = val2;
        val2 = tmp;
    }
    public void Swap(int index1, int index2)
    { 
        if (_inventoryDatas[index1].id == _inventoryDatas[index2].id)
        {
            if(index1 == index2)
            {
                return;
            }
            InsertItem(_inventoryDatas[index2], index1);
            DeleteItem(_inventoryDatas[index2], index2);

            return;
        }
        Swap(ref _inventoryDatas[index1], ref _inventoryDatas[index2]);
    }

}
