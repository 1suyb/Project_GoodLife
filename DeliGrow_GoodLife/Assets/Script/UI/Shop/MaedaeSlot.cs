using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaedaeSlot : Slot
{
    [SerializeField] private ShopMaedaeUI shopMaedaeUI;



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
        Debug.Log("clicked");
    }

    public override void MoustRightClick()
    {
        if (shopMaedaeUI.isPoped == true) return;

        if (Input.GetMouseButtonDown(1))
        {
            if ((Input.GetKey(KeyCode.LeftShift)))
            {
                shopMaedaeUI.PopUpWindow(_itemData);
                return;
            }
            shopMaedaeUI.PurchaseSingleItem(new ItemData(_itemData.id, _itemData.itemSprite, _itemData.itemName, _itemData.itemDescription, _itemData.category, 1, _itemData.itemPrice));
        }

    }

    public override void DataUpdate()
    {
        if ((_itemData.itemCount <= 0) || (_itemData.id == 0))
        {
            OffSlot();
            return;
        }
        _icon.sprite = _itemData.itemSprite;
        _count.text = _itemData.itemPrice.ToString();
        OnSlot();
    }




    private void ShowItemDescription()
    {
        shopMaedaeUI.ShowItemDescriptionWindow(_itemData);
    }
    private void HideItemDescription()
    {
        shopMaedaeUI.HideItemDescriptionWindow();
    }

}
