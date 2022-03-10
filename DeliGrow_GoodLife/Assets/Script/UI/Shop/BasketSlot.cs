using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketSlot : Slot
{
    [SerializeField]
    private ShopBasketUI shopBasketUI;
    

    public override void SetSlotData(ItemData itemData)
    {
        base.SetSlotData(itemData);
        shopBasketUI.purchaseAmount += itemData.itemCount;
        // shopBasketUI.purchaseAmount += itemData.itemCount * itemData.itemPrice; (향후 수정)
        shopBasketUI.setPurchaseAmount();

    }

    public override void SetSlotData(int itemcount)
    {
        base.SetSlotData(itemcount);
        shopBasketUI.purchaseAmount += _itemData.itemCount * itemcount;
        // shopBasketUI.purchaseAmount += _itemData.itemPrice * itemcount; (향후 수정)
        shopBasketUI.setPurchaseAmount();
    }

    public override void MouseEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void MouseExit()
    {
        throw new System.NotImplementedException();
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
