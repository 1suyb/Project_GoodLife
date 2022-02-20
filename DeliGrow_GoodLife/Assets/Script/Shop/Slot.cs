using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour
{
    [Header("������ ǥ��")]
    [Tooltip("������ ������")]
    [SerializeField] private Image _icon;
    [Tooltip("������ ī��Ʈ")]
    [SerializeField] private Text _count;
    [Header("����")]
    [Tooltip("��Ȱ��ȭ �����϶� �÷�")]
    [SerializeField] private Color _deactiveColor;

    private Sprite _itemIconSprite;
    private int _itemCount;
    private Category _itemCategory;

    public void SetSlotData(Sprite itemicon, int itemcount, Category itemcategory)
    {
        _itemIconSprite = itemicon;
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
        _icon.sprite = _itemIconSprite;
        _count.text = _itemCount.ToString();
    }

    public abstract void MouseEnter();
    public abstract void MouseExit();
    public abstract void MouseLeftClick();
    public abstract void MoustRightClick();

}
