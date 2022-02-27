using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour
{
    
    [Header("������ ǥ��")]
    [Tooltip("������ ������")]
    [SerializeField] protected Image _icon;
    [Tooltip("������ ī��Ʈ")]
    [SerializeField] protected Text _count;
    [Header("����")]
    [Tooltip("��Ȱ��ȭ �����϶� �÷�")]
    [SerializeField] protected Color _deactiveColor;


    protected Sprite _itemIconSprite;
    protected int _itemCount;
    protected Category _itemCategory;

    public void SetSlotData(Sprite itemicon, int itemcount, Category itemcategory)
    {
        _itemIconSprite = itemicon;
        Debug.Log("�Ű������ι޾ƿ��°�", itemicon);
        Debug.Log(_itemIconSprite);
        _itemCount = itemcount;
        _itemCategory = itemcategory;
        DataUpdate();
    }
    public void SetSlotData(int itemcount)
    {
        _itemCount = itemcount;
        DataUpdate();
    }
    public void DataUpdate()
    {
        if (_itemCount <= 0)
        {
            OffSlot();
            return;
        }                   
        _icon.sprite = _itemIconSprite;
        _count.text = _itemCount.ToString();
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
