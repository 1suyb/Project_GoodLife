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
        // shopBasketUI.Amount += itemData.itemCount * itemData.itemPrice; (���� ����)
        shopBasketUI.setPurchaseAmount();

    }

    public override void SetSlotData(int itemcount)
    {
        base.SetSlotData(itemcount);
        shopBasketUI.Amount += _itemData.itemCount * itemcount;
        // shopBasketUI.Amount += _itemData.itemPrice * itemcount; (���� ����)
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
        Debug.Log("�Լ�����");
      
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("if�� ����");
            _itemData.itemCount = 0;
            _itemData.id = 0;
            DataUpdate();
        }
    }
}
