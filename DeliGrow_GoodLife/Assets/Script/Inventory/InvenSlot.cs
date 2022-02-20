using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : Slot2
{
    private InventoryUI invenui;
    private int _index;
    private bool _isActive;
    private bool _isSelecting;
    private bool _isSelected;
    private bool _isMoving;

    private float _currentPointDownTime;
    private float _maxPointDownTime;

    public void SetSlotData(ItemData item, int index)
    {
        SetSlotData(item.itemSprite, item.itemCount, item.category);
        _index = index;
        
    }

    public void Activate()
    {
        _icon.color = Color.white;
        _isActive = true;
    }
    public void DeActivate()
    {
        _icon.color = _deactiveColor;
        _isActive = false;
    }

    void Update()
    {
        if (_isSelecting)
        {
            Debug.Log(_currentPointDownTime);
            _currentPointDownTime += Time.unscaledDeltaTime;
            if (_currentPointDownTime >= _maxPointDownTime)
            {
                _isSelecting = false;
                _isMoving = true;
                _currentPointDownTime = 0;
                //HideItemDescription();
                //m_inventoryUI.MovingItem(m_item.itemSprite);
            }
        }
    }

    public override void MouseEnter()
    {
        
    }

    public override void MouseExit()
    {

    }

    public override void MouseLeftClick()
    {

    }

    public override void MoustRightClick()
    {

    }
}
