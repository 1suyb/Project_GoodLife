using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : UI
{
    [SerializeField]
    private GameObject background;
    #region
    public Inventory inventory;

    // �κ��丮 slots
    private InventorySlot[] m_inventorySlots;

    [Tooltip("�κ��丮 ī�װ����� �θ� ������Ʈ")]
    [SerializeField]
    private GameObject m_inventoryCategoryParentObject;

    private InventoryCategory[] m_inventoryCategories;

    [Tooltip("������ �����϶� ���� GameObject")]
    [SerializeField]
    private GameObject m_slotMoveSlotObject;
    private Image m_moveSlotImage;

    [Tooltip("������ ���� �����������Ʈ")]
    [SerializeField]
    private GameObject m_itemDescriptionWindowObject;

    private ItemDescription m_itemDescriptionWindow;

    [Tooltip("������ ���� ��������ӿ�����Ʈ")]
    [SerializeField]
    private GameObject m_itemSelectWindowGO;

    private ItemSeletWindow m_itemSeletWindow;

    [Tooltip("������ ������ ������ ���ӿ�����Ʈ")]
    private GameObject m_itemDivideSlotWindowGO;

    private ItemDevideWindow m_itemDevideWindw;

    [Tooltip("�� �ؽ�Ʈ ������Ʈ")]
    [SerializeField]
    private GameObject m_GoldTextGO;

    private Text m_goldText;

    [Tooltip("�˾� ������Ʈ")]
    [SerializeField]
    private GameObject m_popUpGO;

    private ItemPopUp m_popUp;

    [Range(0, 1)]
    [Tooltip("��Ȱ��ȭ�� RGB��")]
    [SerializeField]
    private float deactivateRGB;

    [Range(0, 1)]
    [Tooltip("��Ȱ��ȭ�� Alpha��")]
    [SerializeField]
    private float deactivateAlpha;
    #endregion

    #region
    // ��Ȱ��ȭ�� ������ �÷�
    [SerializeField]
    private Vector4 m_deactivateColor;

    public Vector4 deactivateColor
    {
        get => m_deactivateColor;
        set => m_deactivateColor = value;
    }

    // Ȱ��ȭ�� ������ �÷�
    [SerializeField]
    private Vector4 m_activateColor;
    public Vector4 activateColor
    {
        get => m_activateColor;
        set => m_activateColor = value;
    }

    // �������� ����
    [SerializeField]
    private InventorySlot m_allocatedSlot;
    public InventorySlot allocatedSlot
    {
        get => m_allocatedSlot;
        set => m_allocatedSlot = value;
    }

    // ���õ� ������
    private ItemData m_selectedItem;
    public ItemData selectedItem
    {
        get => m_selectedItem;
        set => m_selectedItem = value;
    }




    [SerializeField]
    private bool m_isMoving = false;
    public bool isMoving
    {
        get => m_isMoving;
        set => m_isMoving = value;
    }
    private bool isShowDescription = false;
    #endregion

    public void Initialize()
    {
        Debug.Log("Initializeȣ��");
        inventory._inventoryUI = this;

        m_deactivateColor = new Vector4(deactivateRGB, deactivateRGB, deactivateRGB, deactivateAlpha);
        m_activateColor = Color.white;

        m_moveSlotImage = m_slotMoveSlotObject.GetComponent<Image>();
        m_inventoryCategories = m_inventoryCategoryParentObject.GetComponentsInChildren<InventoryCategory>();
        m_itemDescriptionWindow = m_itemDescriptionWindowObject.GetComponent<ItemDescription>();
        m_goldText = m_GoldTextGO.GetComponent<Text>();
        m_popUp = m_popUpGO.GetComponent<ItemPopUp>();
        m_itemDevideWindw = m_itemDescriptionWindowObject.GetComponent<ItemDevideWindow>();
        m_inventorySlots = this.GetComponentsInChildren<InventorySlot>();
        
        for (int i = 0; i < m_inventorySlots.Length; i++)
        {
            
            m_inventorySlots[i].Initialize();
            if (inventory.inventoryDatas[i].id != 0)
            {
                Debug.Log(inventory.inventoryDatas[i].itemSprite);
                m_inventorySlots[i].SetSlotData(inventory.inventoryDatas[i], i);
            }
            else
            {
                m_inventorySlots[i].ClearSlot();
            }
        }
        UpdateGold();
    }
    public override bool Open()
    {
        Debug.Log("Openȣ��");
        if (background.activeSelf == true)
        {
            background.SetActive(false);
        }
        if (m_inventorySlots == null)
        {
            Initialize();
        }
        foreach(var item in m_inventorySlots)
        {
            item.SlotUpdate();
        }
        Unemphasize();
        UpdateGold();
        background.SetActive(true);
        return true;
    }

    public bool PutInSlot(int invenindex)
    {
        if(inventory.inventoryDatas[invenindex] != null)
        {
            m_inventorySlots[invenindex].SetSlotData(inventory.inventoryDatas[invenindex],invenindex);
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
        m_slotMoveSlotObject.SetActive(true);
    }
    public void EndMoving(InventorySlot slot) 
    {
        m_isMoving = false;
        if (m_allocatedSlot != null && m_allocatedSlot != slot)
        {
            inventory.Swap(slot.slotData.inventoryIndex, m_allocatedSlot.slotData.inventoryIndex);
            
            Swap(allocatedSlot, slot);
            
        }
        else
        {
            m_allocatedSlot = null;
        }
        m_moveSlotImage.gameObject.SetActive(false);
    }
    public void SelectItem(int invenindex)
    {
        m_selectedItem = inventory.inventoryDatas[invenindex];
        m_itemSelectWindowGO.transform.position = m_inventorySlots[invenindex].gameObject.transform.position + new Vector3(0, -50, 0);
        m_itemSelectWindowGO.SetActive(true);
    }
    public void UpdateGold()
    {
        m_goldText.text = inventory.gold.ToString();
    }
    
    public void SortButton()
    {
        inventory.SortItem();
        for(int i = 0; i < m_inventorySlots.Length; i++)
        {
            m_inventorySlots[i].SetSlotData(inventory.inventoryDatas[i], i);
        }
    }

    public void DumpItemButton()
    {
        m_popUp.PopUp("������", m_selectedItem, DumpItem);
    }
    public void DumpItem(ItemData item)
    {
        if (!inventory.TakeOutItem(item))
        {
            // ���н� ��� �˸�.
        }
    }

    public void ItemDevideButton()
    {
        m_popUp.PopUp("������", m_selectedItem, ItemDevide);
    }
    public void ItemDevide(ItemData item)
    {
        //m_itemDevideWindw
    }

    public void Warning()
    {

    }
    static public void Swap(InventorySlot slot1, InventorySlot slot2)
    {
        InventorySlot tmpslot = slot1;
        slot1.SetSlotData(slot2);
        slot2.SetSlotData(tmpslot);
    }

    // Emphasize ���� �κ�
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

    public void Sort()
    {
        for (int i = 0; i < m_inventorySlots.Length; i++)
        {
            m_inventorySlots[i].SetSlotData(inventory.inventoryDatas[i], i);
        }
    }

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
