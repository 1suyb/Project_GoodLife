using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBasketUI : ShopUI
{
    [SerializeField]
    private GameObject purchaseAmountText;
    [SerializeField]
    private ShopInventoryUI shopInventoryUI;

    public int purchaseAmount;

    public override void Open()
    {
        base.Open(1);
        purchaseAmount = 0;
        setPurchaseAmount();
       for(int i = 0; i < slots.Length; i++)
        {
            slots[i].gameObject.SetActive(false);
        }

    }

    public void setPurchaseAmount()
    {
        purchaseAmountText.GetComponent<Text>().text = purchaseAmount.ToString();
    }

    public void clearBasket()
    {
        for( int i = 0; i < slots.Length; i++ )
        {
            slots[i]._itemData.itemCount = 0;
            slots[i]._itemData.id = 0;
            slots[i].gameObject.SetActive(false);

            purchaseAmount = 0;
            setPurchaseAmount();
        }
    }

    public void purchaseItems()
    {
        for( int i = 0; i < slots.Length; i++ )
        {
            if (slots[i]._itemData.itemCount <= 0)
                continue;
            shopInventoryUI.putItem(slots[i]._itemData);
        }
        clearBasket();
    }

}
