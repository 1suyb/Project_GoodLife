using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour
{
    
    [Header("아이템 표시")]
    [Tooltip("아이템 아이콘")]
    [SerializeField] protected Image _icon;
    [Tooltip("아이템 카운트")]
    [SerializeField] protected Text _count;
    [Header("색상")]
    [Tooltip("비활성화 상태일때 컬러")]
    [SerializeField] protected Color _deactiveColor;

    /*
    protected Sprite _itemIconSprite;
    protected int _itemCount;
    protected Category _itemCategory;
    protected int _itemId; 
    */

    public ItemData _itemData;

    public void SetSlotData(ItemData itemData)
    {
        // _itemIconSprite = itemicon;
        //Debug.Log("매개변수로받아오는거", itemicon);
        // Debug.Log(_itemIconSprite);
        // _itemCount = itemcount;
        //_itemCategory = itemcategory;
        // _itemId = itemId;

        _itemData = itemData;
        DataUpdate();
    }
    /*
    public void SetSlotData(int itemcount)
    {
        _itemCount = itemcount;
        DataUpdate();
    }
    */
    public void DataUpdate()
    {
        if ( (_itemData.itemCount <= 0) || (_itemData.id == 0) )
        {
            OffSlot();
            return;
        }
        _icon.sprite = _itemData.itemSprite;
        _count.text = _itemData.itemCount.ToString();
        OnSlot();
    }

    public void OffSlot()
    {
        _icon.gameObject.SetActive(false);
        _count.gameObject.SetActive(false);
    }

    public void OnSlot()
    {
        _icon.gameObject.SetActive(true);
        _count.gameObject.SetActive(true);
    }

    public abstract void MouseEnter();
    public abstract void MouseExit();
    public abstract void MouseLeftClick();
    public abstract void MoustRightClick();

}
