using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : ShopUI
{
    [SerializeField]
    private ShopBasketUI shopBasketUI;

    private Slot[] basketSlots;

    public override void Open()
    {
        base.Open(1);

        basketSlots = shopBasketUI.slots;
        for (int i = 0; i < slots.Length; i++)
        {         
                slots[i].SetSlotData(inventory.inventoryDatas[i]);
        }
    }
    public void SellSingleItem(ItemData itemData)
    {      
        for (int i = 0; i < basketSlots.Length; i++)
        {
            if (itemData.id == basketSlots[i]._itemData.id)
            {
                basketSlots[i].SetSlotData(1);
                return;
            }
        }
        for (int i = 0; i < basketSlots.Length; i++)
        {
            if (basketSlots[i]._itemData.itemCount == 0)
            {
                basketSlots[i].SetSlotData(itemData.Clone());
                return;
            }
        }
        Debug.Log("½½·Ô ²Ë Âü");

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

    public bool returnIsPurchase()
    {
        return shopBasketUI.isPurchase;
    }



}
