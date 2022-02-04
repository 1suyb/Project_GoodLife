using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Tooltip("인벤토리 슬롯 그리드 오브젝트를 넣으면 됩니다.")]
    [SerializeField]
    private InventoryUI m_inventoryUI;
    public InventoryUI inventoryUI
    {
        get; set;
    }
    [Tooltip("ItemIcon을 넣을 게임 오브젝트")]
    [SerializeField]
    private Image m_itemIconImage;
    //private GameObject itemIconObject;


    public Image itemIconImage
    {
        get => m_itemIconImage;
    }

    [Tooltip("ItemCount텍스트를 넣을 게임 오브젝트")]
    [SerializeField]
    private Text m_itemCountText;
    //private GameObject itemCountObject;


    public Text itemCountText
    {
        get => m_itemCountText;
    }
    [SerializeField]
    private SlotData m_slotData = new SlotData();
    public SlotData slotData
    {
        get => m_slotData;
    }
    
    [Tooltip("아이템 이동하는데 눌러야하는 시간")]
    [SerializeField]
    private float m_maxPointDownTime;
    public float maxPointDownTime
    {
        get;set;
    }
    private float m_currentPointDownTime;

    [SerializeField]
    public Vector4 deactivateColor;
    [SerializeField]
    public Vector4 activateColor;

    [SerializeField]
    private bool isActivate = true;
    [SerializeField]
    private bool isMoving = false;
    private bool isSelected = false;
    private bool isShowing = false;

    public void Initialize()
    {
    }
    public void SetSlotData(ItemData inventoryitem, int _itemIndex)
    {
        Debug.Log(inventoryitem.itemSprite);

        if (m_slotData.inventoryIndex == _itemIndex)
        {
            m_slotData.itemCount = inventoryitem.itemCount;
        }
        else
        {
            m_slotData.itemCount = inventoryitem.itemCount;
        }
        m_slotData.itemicon = inventoryitem.itemSprite;
        m_slotData.inventoryIndex = _itemIndex;
        m_slotData.itemCategory = inventoryitem.category;
        SlotUpdate();
    }
    public void ClearSlot()
    {
        m_slotData.itemicon = null;
        m_slotData.itemCount = 0;
        m_slotData.inventoryIndex = -1;
        m_slotData.itemCategory = Category.NONE;
        SlotUpdate();

    }

    public void SlotUpdate()
    {
        m_itemIconImage.sprite = m_slotData.itemicon;
        m_itemCountText.text = m_slotData.itemCount.ToString();

        if (m_slotData.inventoryIndex != -1)
        {
            m_itemIconImage.color = activateColor;
            m_itemCountText.color = Color.black;
        }
        else
        {
            m_itemIconImage.color = Color.clear;
            m_itemCountText.color = Color.clear;
        }
    }

    public void Activate()
    {
        Debug.Log("Activate호출");
        if(slotData.inventoryIndex == -1)
        {
            m_itemCountText.color = Color.clear;
            m_itemIconImage.color = Color.clear;
            isActivate = false;
            return;
        }
        m_itemIconImage.color = m_inventoryUI.activateColor;
        isActivate = true;
    }

    public void Deactivate()
    {
        m_itemIconImage.color = m_inventoryUI.deactivateColor;
        isActivate = false;
    }

    void Update()
    {
        if (isSelected)
        {
            m_currentPointDownTime += Time.deltaTime;
            if(m_currentPointDownTime >= m_maxPointDownTime)
            {
                isSelected = false;
                isMoving = true;
                m_currentPointDownTime = 0;
                HideItemDescription();
                m_inventoryUI.MovingItem(m_slotData.itemicon);
            }
        }
    }

    public void MouseEnter()
    {
        if (!isActivate||slotData.inventoryIndex == -1)
        {
            return;
        }
        if (m_inventoryUI.isMoving == true)
        {
            AllocateInventoryUIPutDownSlot();
        }
        else
        {
            ShowItemDescription();
        }
    }
    public void MouseExit()
    {
        if (isMoving)
        {
            DeacllocateInventoryUIPutDownSlot();
        }
        else
        {
            HideItemDescription();
        }
    }
    public void MouseDown()
    {
        if(m_slotData.inventoryIndex == -1)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isSelected = true;
        }
        else if (Input.GetMouseButton(1))
        {
            
        }
        
    }
    public void MouseUp()
    {
        if (isMoving)
        {
            EndMoving();
        }
        else
        {
            if (isSelected)
            {
                SelecctItem();
            }
        }
        
    }
    private void AllocateInventoryUIPutDownSlot()
    {
        Debug.Log("allocateinventroyuiputdownslot");
        m_inventoryUI.allocatedSlot = this;
    }
    private void ShowItemDescription()
    {
        Debug.Log("ShowItemDescription");
        m_inventoryUI.ShowItemDescription(slotData.inventoryIndex);
    }
    private void DeacllocateInventoryUIPutDownSlot()
    {
        Debug.Log("DeallocateInventoryUIPutDownSlot");
        m_inventoryUI.allocatedSlot = null;
    }
    private void HideItemDescription()
    {
        Debug.Log("HideItemdescription");
        m_inventoryUI.HideItemDescription();
    }
    private void EndMoving()
    {
        Debug.Log("Endmoving");
        Debug.Log(this.slotData.itemicon);
        isMoving = false;
        m_inventoryUI.EndMoving(this);

        
    }
    private void SelecctItem()
    {
        m_inventoryUI.SelectItem(slotData.inventoryIndex);
        Debug.Log("SlectItem");
        Debug.Log("아이템선택");
        isSelected = false;
    }
    private void ItemUse()
    {

    }

    public void SetSlotData(InventorySlot slot)
    {
        this.m_slotData = slot.slotData;
        SlotUpdate();
    }
    
}
[System.Serializable]
public struct SlotData
{
    public Sprite itemicon;
    public int inventoryIndex;
    public int itemCount;
    public Category itemCategory;
}