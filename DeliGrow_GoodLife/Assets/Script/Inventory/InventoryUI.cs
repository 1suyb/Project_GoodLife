using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : UI
{

    [Tooltip("인벤토리 슬롯 UI")]
    [SerializeField]
    private InventorySlot[] m_inventorySlots;

    [Tooltip("인벤토리 카테고리슬롯 부모 오브젝트")]
    [SerializeField]
    private GameObject m_inventoryCategoryParentObject;

    [Tooltip("인벤토리 카테고리 슬롯 UI")]
    [SerializeField]
    private InventoryCategory[] m_inventoryCategories;

    [Tooltip("아이템슬롯")]
    private GameObject m_slotMoveSlotObject;
    private Image m_moveSlotImage;

    [Tooltip("아이템 설명 윈도우오브젝트")]
    [SerializeField]
    private GameObject m_itemDescriptionWindowObject;
    [Tooltip("아이템 설명 윈도우")]
    private ItemDescription m_itemDescriptionWindow;
    [Tooltip("아이템 선택 윈도우")]
    [SerializeField]
    private GameObject m_itemSlectWindow;

    [Range(0, 1)]
    [Tooltip("비활성화시 RGB값")]
    [SerializeField]
    private float deactivateRGB;

    [Range(0, 1)]
    [Tooltip("비활성화시 Alpha값")]
    [SerializeField]
    private float deactivateAlpha;

    // 비활성화시 적용할 컬러
    private Vector4 m_deactivateColor;
    public Vector4 deactivateColor
    {
        get => m_deactivateColor;
        set => m_deactivateColor = value;
    }

    // 활성화시 적용할 컬러
    private Vector4 m_activateColor;
    public Vector4 activateColor
    {
        get => m_activateColor;
        set => m_activateColor = value;
    }




    private InventorySlot m_allowedSlot;
    public InventorySlot allowedSlot
    {
        get => m_allowedSlot;
        set => m_allowedSlot = value;
    }

    public InventoryData InventoryData;

    [SerializeField]
    private bool m_isMoving = false;
    public bool isMoving
    {
        get => m_isMoving;
        set => m_isMoving = value;
    }

    public override bool Open()
    {
        /* 
         전체 슬롯 초기화
         */
        this.gameObject.SetActive(true);
        return true;
    }

    public void InputItem(int invenindex)
    {
        int slotIndex = SearchSlot(invenindex);
        if (slotIndex != -1)
        {
        }
    }
    public void GetItem(int invenindex)
    {

    }

    public int SearchSlot(int inventoryindex)
    {
        for(int i = 0; i < m_inventorySlots.Length; i++)
        {
            if(m_inventorySlots[i].slotData.inventoryIndex == inventoryindex)
            {
                return i;
            }
        }
        return -1;
    }
    public int SearchNullSlot()
    {
        for(int i = 0; i < m_inventorySlots.Length; i++)
        {
            if(m_inventorySlots[i].slotData.inventoryIndex == -1)
            {
                return i;
            }
        }
        return -1;
    }

    public void ShowItemDescription(int inventoryIndex)
    {

    }
    public void HideItemDescription()
    {

    }
    public void MovingItem(Sprite sprite)
    {
        m_isMoving = true;
        m_moveSlotImage.sprite = sprite;
    }
    public void EndMoving(InventorySlot slot) 
    {
        m_isMoving = false;
        if (allowedSlot != null && allowedSlot==slot)
        {
            SlotData handSlot = slot.slotData;
            ItemData item = InventoryData.inventoryDatas[handSlot.inventoryIndex].Clone(); ;

            slot.SetSlotData(InventoryData.inventoryDatas[allowedSlot.slotData.inventoryIndex], allowedSlot.slotData.inventoryIndex);
            allowedSlot.SetSlotData(item, handSlot.inventoryIndex);
        }
        else
        {
            allowedSlot = null;
        }
    }
    public void EmphasizeItemCategory(Category category)
    {
        foreach(var item in m_inventorySlots)
        {
            if (item.slotData.itemCategory != category)
            {
                item.Deactivate();
            }
        }
    }
    public void EmphasizeCategory(Category category)
    {
        foreach (var item in m_inventoryCategories)
        {
            if (item.category != category)
            {
                item.Deactivate();
            }
        }
    }
    public void EmphasizeItem(int inventoryindex)
    {
        foreach (var item in m_inventorySlots)
        {
            if (item.slotData.inventoryIndex != inventoryindex)
            {
                item.Deactivate();
            }
        }
    }
    public void Unemphasize()
    {
        foreach(var item in m_inventorySlots)
        {
            item.Activate();
        }
        foreach(var item in m_inventoryCategories)
        {
            item.Activate();
        }
    }
    public void UpdateGold(int addGold)
    {

    }
    public void DumpItem()
    {

    }
    public void ItemDevide()
    {

    }

    void Awake() {
        m_deactivateColor = new Vector4(deactivateRGB, deactivateRGB, deactivateRGB, deactivateAlpha);
        m_activateColor = new Vector4(1, 1, 1, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_moveSlotImage = m_slotMoveSlotObject.GetComponent<Image>();
        m_inventorySlots = this.GetComponentsInChildren<InventorySlot>();
        m_inventoryCategories = m_inventoryCategoryParentObject.GetComponentsInChildren<InventoryCategory>();
        m_itemDescriptionWindow = m_itemDescriptionWindowObject.GetComponent<ItemDescription>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            m_slotMoveSlotObject.transform.position = Input.mousePosition;
        }
    }
}
