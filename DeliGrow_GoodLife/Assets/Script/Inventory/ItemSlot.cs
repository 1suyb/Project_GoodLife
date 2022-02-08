using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot : MonoBehaviour
{
    [Tooltip("InventoryUI")]
    [SerializeField]
    private InventoryUI m_inventoryUI;
    [SerializeField]
    private Image m_image;
    [SerializeField]
    private Text m_count;
    [SerializeField]
    private ItemData m_item;

    public delegate void FunctionPointer();
    public FunctionPointer act;
    public void SlotUpdate(ItemData item)
    {
        m_item = item;
        m_image.sprite = m_item.itemSprite;
        m_count.text = m_item.itemCount.ToString();
    }
    public void MouseEnter()
    {
        m_inventoryUI.ShowItemDescription(m_item);
    }
    public void MouseExit()
    {
        m_inventoryUI.HideItemDescription();
    }
    public void MouseDown()
    {
        m_inventoryUI.MovingItem(m_item.itemSprite);
    }
    public void MouseUp()
    {
        
        if (act != null&& m_inventoryUI.EndMoving(m_item)){
            act();
        }
    }
}
