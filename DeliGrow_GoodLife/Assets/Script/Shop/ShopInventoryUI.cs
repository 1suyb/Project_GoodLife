using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : UI
{
    [SerializeField]
    private GameObject inventory_Panel;
    [SerializeField]
    private Inventory inventory;
     [SerializeField]
    private GameObject go_DescriptionWindow;
   

    private Slot[] slots;
    private bool isShowDescription = false;

    public void Open()
    {
        inventory_Panel.SetActive(true);
        slots = this.gameObject.GetComponentsInChildren<Slot>();

        for (int i = 0; i < slots.Length; i++)
        {
          
                slots[i].SetSlotData(inventory.inventoryDatas[i].itemSprite, inventory.inventoryDatas[i].itemCount, inventory.inventoryDatas[i].category);

        }

    }
}
