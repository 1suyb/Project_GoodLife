using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : Slot2
{
    // [Header("아이템 표시")]
    // [Tooltip("아이템 아이콘")]
    // [SerializeField] protected Image _icon;
    // [Tooltip("아이템 카운트")]
    // [SerializeField] protected Text _count;
    // [Header("색상")]
    // [Tooltip("비활성화 상태일때 컬러")]
    // [SerializeField] protected Color _deactiveColor;

    // protected Sprite _itemIconSprite;
    // protected int _itemCount;
    // protected Category _itemCategory;
    [Header("인벤토리")]
    [Tooltip("인벤토리 슬롯의 부모 오브젝트를 넣는 곳")]
    [SerializeField] private InventoryUI _invenUI;
    [Tooltip("롱키시간")]
    [SerializeField]private float _maxPointDownTime;

    private int _index;
    public int index
    {
        get => _index;
        set => _index = value;
    }
    private bool _isActive;
    private bool _isSelecting;
    private bool _isSelected;
    private bool _isMoving;

    private float _currentPointDownTime;
    

    // public void SetSlotData(Sprite itemicon, int itemcount, Category itemcategory)
    // {
    //     _icon.gameObject.SetActive(false);
    //     _count.gameObject.SetActive(false);
    // 
    //     _itemIconSprite = itemicon;
    //     _itemCount = itemcount;
    //     _itemCategory = itemcategory;
    //     DataUpdate();
    // }
    // public void SetSlotData(int itemcount)
    // {
    //     _itemCount = itemcount;
    //     DataUpdate();
    // }
    // public void DataUpdate()
    // {
    //     if (_itemCount <= 0)
    //     {
    //         _icon.gameObject.SetActive(false);
    //         _count.gameObject.SetActive(false);
    //     }
    // 
    //     _icon.sprite = _itemIconSprite;
    //     _count.text = _itemCount.ToString();
    // }

    public void SetSlotData(ItemData item)
    {
        if (item.id != 0)
        {
            SetSlotData(item.itemSprite, item.itemCount, item.category);
        }
        else
        {
            SetSlotData(0);
        }
        
        
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
    public void Initialize(int index)
    {
        if (_invenUI == null)
        {
            _invenUI = GetComponentInParent<InventoryUI>();
        }

        _index = index;

    }


    void Update()
    {
        if (_isSelecting)
        {
            _currentPointDownTime += Time.unscaledDeltaTime;
            if (_currentPointDownTime >= _maxPointDownTime)
            {
                _isSelecting = false;
                _isMoving = true;
                _currentPointDownTime = 0;
                HideItemDescription();
                _invenUI.MovingItem(_itemIconSprite);
            }
        }
    }

    public override void MouseEnter()
    {
        if (_invenUI.isMoving == true)
        {
            AllocateInventoryUIPutDownSlot();
            return;
        }
        if (!_isActive || _itemCount <= 0)
            return;

        

        else
        {
            ShowItemDescription();
        }
    }

    public override void MouseExit()
    {
        if (_invenUI.isMoving)
        {
            DeacllocateInventoryUIPutDownSlot();
        }
        else
        {
            HideItemDescription();
        }
    }

    public override void MouseButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseLeftDown();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            MoustRightDown();
        }
    }
    public override void MouseButtonUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            MouseLeftUp();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            MoustRightUp();
        }
    }

    public override void MouseLeftDown() {
        if (_invenUI.isSelection)
        {
            return;
        }

        if(_itemCount<= 0)
        {
            return;
        }
        _isSelecting = true;

    }
    public override void MouseLeftUp() {
        if (_invenUI.isSelection)
        {
            _invenUI.DeSelect();
            return;
        }
        if (_isMoving)
        {
            EndMoving();
            return;
        }
        if (_isSelecting)
        {
            SelecctItem();
        }
    }
    public override void MoustRightDown() { 

    }
    public override void MoustRightUp() { 

    }

    private void AllocateInventoryUIPutDownSlot()
    {
        Debug.Log("allocateinventroyuiputdownslot");
        _invenUI.allocatedSlot = _index;
    }
    private void ShowItemDescription()
    {
        Debug.Log("ShowItemDescription");
        _invenUI.ShowItemDescription(_index);
    }
    private void DeacllocateInventoryUIPutDownSlot()
    {
        Debug.Log("DeallocateInventoryUIPutDownSlot");
        _invenUI.allocatedSlot = -1;
    }
    private void HideItemDescription()
    {
        Debug.Log("HideItemdescription");
        _invenUI.HideItemDescription();
    }
    private void EndMoving()
    {
        _isMoving = false;
        _invenUI.EndMoving(_index);
    }
    private void SelecctItem()
    {
        _invenUI.SelectItem(_index);
        _isSelected = true;
        _isSelecting = false;
    }
}
