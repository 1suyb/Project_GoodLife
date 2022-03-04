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
        Debug.Log("제발 되어주십시오");
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("계십니까");
            if ((Input.GetKeyDown(KeyCode.LeftShift)))
            {
                shopMaedaeUI.PopUpWindow(_itemData);
                return;
            }
            shopMaedaeUI.PurchaseSingleItem(_itemData);
        }

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
