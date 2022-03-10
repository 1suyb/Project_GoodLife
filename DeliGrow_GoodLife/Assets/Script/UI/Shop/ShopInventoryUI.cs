using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : ShopUI
{

    public override void Open()
    {
        base.Open(1);

        for (int i = 0; i < slots.Length; i++)
        {         
                slots[i].SetSlotData(inventory.inventoryDatas[i]);
        }
    }

    public void putItem(ItemData itemData)
    {
        for( int i = 0; i < slots.Length; i++ )
        {
            if( itemData.id == slots[i]._itemData.id )
            {
                slots[i].SetSlotData(itemData.itemCount);
                return;
            }
        }
        for( int i = 0; i < slots.Length; i++ )
        {
            if( slots[i]._itemData.id <= 0 )
            {
                slots[i].SetSlotData(itemData.Clone());
                return;
            }
        }
        Debug.Log("½½·Ô ²Ë Âü");
    }



}
