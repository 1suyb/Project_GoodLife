using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDevideWindow : MonoBehaviour
{
    [SerializeField]
    ItemSlot slot;

    public void OpenDevideWindow(ItemData item)
    {
        this.gameObject.SetActive(true);
        slot.act = CloseDevideWindow;
        InputSlot(item);
    }
    public void CloseDevideWindow()
    {
        gameObject.SetActive(false);
        
    }

    public void InputSlot(ItemData item)
    {
        slot.SlotUpdate(item);
    }
}
