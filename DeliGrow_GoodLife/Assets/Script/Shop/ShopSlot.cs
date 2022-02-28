using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : Slot
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
        throw new System.NotImplementedException();
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
