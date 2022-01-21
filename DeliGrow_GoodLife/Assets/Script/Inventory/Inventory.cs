using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private InventoryUI _inventoryUI;
    [SerializeField]
    private InventoryData _inventoryData;
    public void InputItem(ItemData item)
    {
        _inventoryUI.InputItem(_inventoryData.InputItem(item));
    }
    public void GetItem(ItemData item)
    {
        _inventoryUI.GetItem(_inventoryData.GetItem(item));
    }
    public void SortItem()
    {

    }
    public void InputGold()
    {

    }
    public void GetGold()
    {

    }
    
    public void UseItem()
    {

    }

}
