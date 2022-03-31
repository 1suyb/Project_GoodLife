using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : ShopUI
{
    [SerializeField]
    private ShopBasketUI shopBasketUI;
    [SerializeField]
    private GameObject popUp;

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
    {   if( itemData.category == Category.QUEST )
        {
            warning.ShowWaring("����Ʈ �������� �Ǹ��� �� �����ϴ�!");
            return;
        }
        // Ư����� ������ ����ó��
    
        for (int i = 0; i < basketSlots.Length; i++)
        {
            if (itemData.id == basketSlots[i]._itemData.id)
            {
                basketSlots[i].SetSlotData(1);
                itemData.itemCount -= 1;
                return;
            }
        }
        for (int i = 0; i < basketSlots.Length; i++)
        {
            if (basketSlots[i]._itemData.itemCount == 0)
            {
                basketSlots[i].SetSlotData(new ItemData(itemData.id, itemData.itemSprite, itemData.itemName, itemData.itemDescription, itemData.category, 1));
                itemData.itemCount -= 1;
                return;
            }
        }
        Debug.Log("���� �� ��");
        warning.ShowWaring("�ٱ��� ������ �����մϴ�!");

    }

    public void SellItems(ItemData itemData, ItemData origin, ShopInventorySlot slot)
    {
        if( itemData.itemCount > origin.itemCount )
        {
            warning.ShowWaring("������ �������� ���� �ʰ��Ͽ����ϴ�!");
            setIsPopedFalse();
            return;
        }
        for (int i = 0; i < basketSlots.Length; i++)
        {
            if (itemData.id == basketSlots[i]._itemData.id)
            {
                basketSlots[i].SetSlotData(itemData.itemCount);
                origin.itemCount -= itemData.itemCount;
                slot.DataUpdate();               
                setIsPopedFalse();
                return;
            }
        }
        for (int i = 0; i < basketSlots.Length; i++)
        {
            if (basketSlots[i]._itemData.itemCount == 0)
            {
                basketSlots[i].SetSlotData(itemData.Clone());
                origin.itemCount -= itemData.itemCount;
                slot.DataUpdate();
                setIsPopedFalse();
                return;
            }
        }
        Debug.Log("���� �� ��");
        warning.ShowWaring("�ٱ��� ������ �����մϴ�!");
    }
    
    public void PopUpWindow(ItemData itemData, ShopInventorySlot slot)
    {
        setIsPopedTrue();
        popUp.GetComponent<ItemPopUp>().PopUp("�Ǹ� ����", itemData, slot, SellItems, setIsPopedFalse);
    }
    public bool putItem(ItemData itemData)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (itemData.id == slots[i]._itemData.id)
            {
                slots[i].SetSlotData(itemData.itemCount);
                return true;
            }
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i]._itemData.id <= 0)
            {
                slots[i].SetSlotData(itemData.Clone());
                return true;
            }
        }
        warning.ShowWaring("�κ��丮 ������ �����մϴ�!");
        return false;
    }

    public void setIsPopedFalse()
    {
        isPoped = false;
        shopBasketUI.setIsPopedFalse();
    }

    public void setIsPopedTrue()
    {
        isPoped = true;
        shopBasketUI.setIsPopedTrue();
    }

    public bool returnIsPurchase()
    {
        return shopBasketUI.isPurchase;
    }



}
