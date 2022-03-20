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
        shopBasketUI.Amount += itemData.itemCount;
        // shopBasketUI.Amount += itemData.itemCount * itemData.itemPrice; (향후 수정)

        if (shopBasketUI.isPurchase == true) shopBasketUI.setPurchaseAmount();
        else shopBasketUI.setSellAmount();
    }

    public override void SetSlotData(int itemcount)
    {
        base.SetSlotData(itemcount);
        shopBasketUI.Amount += _itemData.itemCount * itemcount;
        // shopBasketUI.Amount += _itemData.itemPrice * itemcount; (향후 수정)

        if (shopBasketUI.isPurchase == true) shopBasketUI.setPurchaseAmount();
        else shopBasketUI.setSellAmount();
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
      
        if (Input.GetMouseButtonDown(1))
        {
            if(shopBasketUI.isPurchase == true)
            {
                shopBasketUI.Amount -= _itemData.itemCount;
                // shopBasketUI.Amount -= _itemData.itemCount * _itemData.itemPrice; (향후 수정)
                if (shopBasketUI.isPurchase == true) shopBasketUI.setPurchaseAmount();
                else shopBasketUI.setSellAmount();
                _itemData.itemCount = 0;
                _itemData.id = 0;
                DataUpdate();
                return;
            }
            shopBasketUI.iPutItem(_itemData);
            shopBasketUI.Amount -= _itemData.itemCount;
            // shopBasketUI.Amount -= _itemData.itemCount * _itemData.itemPrice; (향후 수정)
            if (shopBasketUI.isPurchase == true) shopBasketUI.setPurchaseAmount();
            else shopBasketUI.setSellAmount();
            _itemData.itemCount = 0;
            _itemData.id = 0;
            DataUpdate();
        }
    }
}
