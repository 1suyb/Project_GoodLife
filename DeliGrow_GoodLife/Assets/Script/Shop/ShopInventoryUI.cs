using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : ShopUI
{


    public override void Open()
    {
        base.Open();
        slots = this.gameObject.GetComponentsInChildren<Slot>();

        for (int i = 0; i < slots.Length; i++)
        {         
                slots[i].SetSlotData(inventory.inventoryDatas[i]);
        }
    }





}
