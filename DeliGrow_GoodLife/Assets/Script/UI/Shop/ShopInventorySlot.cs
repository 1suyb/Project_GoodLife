using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventorySlot : Slot
{
    [SerializeField] private ShopInventoryUI shopInventoryUI;


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
        if ( (shopInventoryUI.isPoped == true) || (shopInventoryUI.returnIsPurchase() == true) ) return;

        if (Input.GetMouseButtonDown(1))
        {
            if ((Input.GetKey(KeyCode.LeftShift)))
            {
                shopInventoryUI.PopUpWindow(_itemData, this);
                return;
            }
            shopInventoryUI.SellSingleItem(_itemData);
            DataUpdate();
        }
    }
}
