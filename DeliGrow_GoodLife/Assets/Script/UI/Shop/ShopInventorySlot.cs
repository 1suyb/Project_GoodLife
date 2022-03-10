using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventorySlot : Slot
{
    [SerializeField] private ShopInventoryUI shopInventoryUI;

    public override void SetSlotData(ItemData itemData)
    {
        base.SetSlotData(itemData);
    }

    public override void SetSlotData(int itemcount)
    {
        base.SetSlotData(itemcount);
    }


    private void ShowItemDescription()
    {
        if (_itemData.id == 0)
            return;
    
        shopInventoryUI.ShowItemDescriptionWindow(_itemData);
    }
    private void HideItemDescription()
    {
        shopInventoryUI.HideItemDescriptionWindow();
    }

    public override void MouseEnter()
    {
        ShowItemDescription();
    }

    public override void MouseExit()
    {
        HideItemDescription();
    }

    public override void MouseLeftClick()
    {
        throw new System.NotImplementedException();
    }

    public override void MoustRightClick()
    {
        throw new System.NotImplementedException();
    }
}
