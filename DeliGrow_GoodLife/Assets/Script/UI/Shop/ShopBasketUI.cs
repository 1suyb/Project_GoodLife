using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBasketUI : ShopUI
{
    [SerializeField]
    private GameObject AmountText;
    [SerializeField]
    private GameObject BalanceText;
    [SerializeField]
    private ShopInventoryUI shopInventoryUI;

    public int Amount;
    public ulong Balance;
    public bool isPurchase;

    public override void Open()
    {
        base.Open(1);
        isPurchase = true;
        Amount = 0;
        Balance = inventory.gold;
        AmountUpdate();
       for(int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);
        }

    }

    public void AmountUpdate()
    {
        AmountText.GetComponent<Text>().text = Amount.ToString();
        BalanceText.GetComponent<Text>().text = Balance.ToString();
    }

    public void setPurchaseAmount()
    {
        Balance = inventory.gold - (ulong)Amount;
        AmountUpdate();
    }

    public void setSellAmount()
    {
        Balance = inventory.gold + (ulong)Amount;
        AmountUpdate();
    }
    public void clearBasket()
    {
        if (shopInventoryUI.isPoped == true) return;

        if(isPurchase == true)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i]._itemData.itemCount = 0;
                slots[i]._itemData.id = 0;
                slots[i].gameObject.SetActive(false);

                Amount = 0;
                Balance = inventory.gold;
                AmountUpdate();
            }
            return;
        }
              
        for( int i = 0; i < slots.Length; i++ )
        {
            shopInventoryUI.putItem(slots[i]._itemData);
            slots[i]._itemData.itemCount = 0;
            slots[i]._itemData.id = 0;
            slots[i].gameObject.SetActive(false);

            Amount = 0;
            Balance = inventory.gold;
            AmountUpdate();
        }
    }

    public void confrimBasket()
    {
        if( isPurchase == true )
        {
            purchaseItems();
            return;
        }
        
        sellItems();
    }
    public void purchaseItems()
    {
        if (shopInventoryUI.isPoped == true) return;

        for ( int i = 0; i < slots.Length; i++ )
        {
            if (slots[i]._itemData.itemCount <= 0)
                continue;
            shopInventoryUI.putItem(slots[i]._itemData);
        }
        inventory.SubGold((ulong)Amount);
        clearBasket();
    }

    public void sellItems()
    {
        if (shopInventoryUI.isPoped == true) return;

        inventory.AddGold((ulong)Amount);

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i]._itemData.itemCount = 0;
            slots[i]._itemData.id = 0;
            slots[i].gameObject.SetActive(false);

            Amount = 0;
            Balance = inventory.gold;
            AmountUpdate();
        }
    }

    public void setIsPopedFalse()
    {
        isPoped = false;
        shopInventoryUI.isPoped = false;
    }

    public void setIsPopedTrue()
    {
        isPoped = true;
        shopInventoryUI.isPoped = true;
    }

    public void iPutItem(ItemData itemData)
    {
        shopInventoryUI.putItem(itemData);
    }

}
