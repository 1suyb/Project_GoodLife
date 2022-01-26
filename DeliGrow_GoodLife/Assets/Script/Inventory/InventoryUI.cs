using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : UI
{
    // 인벤토리 slots
    private InventorySlot[] m_inventorySlots;

    [Tooltip("인벤토리 카테고리슬롯 부모 오브젝트")]
    [SerializeField]
    private GameObject m_inventoryCategoryParentObject;

    private InventoryCategory[] m_inventoryCategories;

    [Tooltip("아이템 움직일때 슬롯 GameObject")]
    [SerializeField]
    private GameObject m_slotMoveSlotObject;
    private Image m_moveSlotImage;

    

    [Tooltip("아이템 설명 윈도우오브젝트")]
    [SerializeField]
    private GameObject m_itemDescriptionWindowObject;

    private ItemDescription m_itemDescriptionWindow;


    [Tooltip("아이템 선택 윈도우게임오브젝트")]
    [SerializeField]
    private GameObject m_itemSelectWindowGO;

    private ItemSeletWindow m_itemSeletWindow;

    [Tooltip("아이템 나누기 윈도우 게임오브젝트")]
    private GameObject m_itemDivideWindowGO;

    [Range(0, 1)]
    [Tooltip("비활성화시 RGB값")]
    [SerializeField]
    private float deactivateRGB;

    [Range(0, 1)]
    [Tooltip("비활성화시 Alpha값")]
    [SerializeField]
    private float deactivateAlpha;

    [Tooltip("돈 텍스트 오브젝트")]
    [SerializeField]
    private GameObject m_GoldTextGO;

    private Text m_goldText;

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

    private InventorySlot m_allocatedSlot;
    public InventorySlot allocatedSlot
    {
        get => m_allocatedSlot;
        set => m_allocatedSlot = value;
    }

    public Inventory inventory;

    [SerializeField]
    private bool m_isMoving = false;
    public bool isMoving
    {
        get => m_isMoving;
        set => m_isMoving = value;
    }
    private bool isShowDescription = false;


    public void Initialize()
    {
        for(int i = 0; i < m_inventorySlots.Length; i++)
        {
            if (inventory.inventoryDatas[i].id != 0)
            {
                Debug.Log("이니셜"+i);
                m_inventorySlots[i].SetSlotData(inventory.inventoryDatas[i], i);
            }
            else
            {
                m_inventorySlots[i].ClearSlot();
            }
        }
    }
    public override bool Open()
    {
        foreach(var item in m_inventorySlots)
        {
            item.SlotUpdate();
        }
        Unemphasize();
        this.gameObject.SetActive(true);
        return true;
    }

    public bool PutInSlot(int invenindex)
    {
        if (inventory.inventoryDatas[invenindex] != null)
        {
            int slotIndex = SearchSlot(invenindex);
            if (slotIndex != -1)
            {
                m_inventorySlots[slotIndex].SetSlotData(inventory.inventoryDatas[invenindex], invenindex);
                return true;
            }
            else
            {
                slotIndex = SearchNullSlot();
                if(slotIndex != -1)
                {
                    m_inventorySlots[slotIndex].SetSlotData(inventory.inventoryDatas[invenindex], invenindex);
                    return true;
                }
            }
        }
        
        return false;
    }
    public bool TakeOutItemAtSlot(int invenindex)
    {
        int slotindex = SearchSlot(invenindex);
        ItemData item = inventory.inventoryDatas[invenindex];
        if (item == null)
        {
            
            if (slotindex != -1)
            {
                m_inventorySlots[slotindex].ClearSlot();
                return true;
            }
        }
        else
        {
            m_inventorySlots[slotindex].SetSlotData(item, invenindex);
            return true;
        }
        return false;
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
        m_itemDescriptionWindow.descriptionItem(inventory.inventoryDatas[inventoryIndex]);
        m_itemDescriptionWindowObject.SetActive(true);
        isShowDescription = true;


    }
    public void HideItemDescription()
    {
        m_itemDescriptionWindowObject.SetActive(false);
        isShowDescription = false;
    }
    public void MovingItem(Sprite sprite)
    {
        m_isMoving = true;
        m_moveSlotImage.sprite = sprite;
    }
    public void EndMoving(InventorySlot slot) 
    {
        m_isMoving = false;
        if (m_allocatedSlot != null && m_allocatedSlot == slot)
        {
            SlotData handSlot = slot.slotData;
            ItemData item = inventory.inventoryDatas[handSlot.inventoryIndex].Clone(); ;

            slot.SetSlotData(inventory.inventoryDatas[m_allocatedSlot.slotData.inventoryIndex], m_allocatedSlot.slotData.inventoryIndex);
            m_allocatedSlot.SetSlotData(item, handSlot.inventoryIndex);
            inventory.Swap(slot.slotData.inventoryIndex, m_allocatedSlot.slotData.inventoryIndex);
        }
        else
        {
            m_allocatedSlot = null;
        }
    }


    // Emphasize 관련 부분
#region
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
#endregion


    public void UpdateGold(ulong gold)
    {
        m_goldText.text = gold.ToString();
    }

    public void Sort()
    {
        for(int i = 0; i < m_inventorySlots.Length; i++)
        {
            m_inventorySlots[i].SetSlotData(inventory.inventoryDatas[i], i);
        }
    }
    public void DumpItem()
    {

    }
    public void ItemDevide()
    {

    }

    void Awake() {
        m_deactivateColor = new Vector4(deactivateRGB, deactivateRGB, deactivateRGB, deactivateAlpha);
        m_activateColor = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_moveSlotImage = m_slotMoveSlotObject.GetComponent<Image>();
        m_slotMoveSlotObject.SetActive(false);
        m_inventorySlots = this.GetComponentsInChildren<InventorySlot>();
        m_inventoryCategories = m_inventoryCategoryParentObject.GetComponentsInChildren<InventoryCategory>();
        inventory._inventoryUI = this;
        m_itemDescriptionWindow = m_itemDescriptionWindowObject.GetComponent<ItemDescription>();
        //m_goldText = m_GoldTextGO.GetComponent<TextMeshProUGUI>();

        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            m_slotMoveSlotObject.transform.position = Input.mousePosition;
        }
        if (isShowDescription)
        {
            m_itemDescriptionWindowObject.transform.position = Input.mousePosition;
        }
    }
}
