using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : UI
{
    [SerializeField]
    private Warning warning;
    [SerializeField]
    private GameObject background;
    //serializeField 선언부
    #region
    [Tooltip("인벤토리")]
    public Inventory inventory;

    [Tooltip("인벤토리 카테고리슬롯 부모 오브젝트")]
    [SerializeField]
    private GameObject m_inventoryCategoryParentObject;

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
    [SerializeField]
    private GameObject m_itemDivideSlotWindowGO;

    private ItemDevideWindow m_itemDevideWindow;

    [Tooltip("돈 텍스트 오브젝트")]
    [SerializeField]
    private GameObject m_GoldTextGO;

    private Text m_goldText;

    [Tooltip("팝업 오브젝트")]
    [SerializeField]
    private GameObject m_popUpGO;

    private ItemPopUp m_popUp;

    [Range(0, 1)]
    [Tooltip("비활성화시 RGB값")]
    [SerializeField]
    private float deactivateRGB;

    [Range(0, 1)]
    [Tooltip("비활성화시 Alpha값")]
    [SerializeField]
    private float deactivateAlpha;
    #endregion

    // 일반 변수 선언부
    #region

    // 인벤토리 slots
    private InventorySlot[] m_inventorySlots;
    private InventoryCategory[] m_inventoryCategories;

    // 비활성화시 적용할 컬러
    private Vector4 m_deactivateColor;
    public Vector4 deactivateColor
    {
        get => m_deactivateColor;
        set => m_deactivateColor = value;
    }

    // 활성화시 적용할 컬러
    private  Vector4 m_activateColor;
    public Vector4 activateColor
    {
        get => m_activateColor;
        set => m_activateColor = value;
    }

    // 내려놓을 슬롯
    private int m_allocatedSlot;
    public int allocatedSlot
    {
        get => m_allocatedSlot;
        set => m_allocatedSlot = value;
    }
    // 선택된 아이템
    private int m_selectedItemIndex;
    public int selectedItem
    {
        get => m_selectedItemIndex;
        set => m_selectedItemIndex = value;
    }
    #endregion
    // is 변수 선언부
    #region
    private bool m_isMoving = false;
    public bool isMoving
    {
        get => m_isMoving;
        set => m_isMoving = value;
    }
    private bool isShowDescription = false;
    private bool isOpen = false;
    #endregion

    public void Initialize()
    {

        inventory._inventoryUI = this;

        m_deactivateColor = new Vector4(deactivateRGB, deactivateRGB, deactivateRGB, deactivateAlpha);
        m_activateColor = new Vector4(1,1,1,1);

        m_moveSlotImage = m_slotMoveSlotObject.GetComponent<Image>();
        m_itemDescriptionWindow = m_itemDescriptionWindowObject.GetComponent<ItemDescription>();
        m_goldText = m_GoldTextGO.GetComponent<Text>();
        m_popUp = m_popUpGO.GetComponent<ItemPopUp>();
        m_itemDevideWindow = m_itemDivideSlotWindowGO.GetComponent<ItemDevideWindow>();
        m_itemSeletWindow = m_itemSelectWindowGO.GetComponent<ItemSeletWindow>();

        m_inventorySlots = this.GetComponentsInChildren<InventorySlot>();
        m_inventoryCategories = m_inventoryCategoryParentObject.GetComponentsInChildren<InventoryCategory>();

        m_allocatedSlot = -1;

        for (int i = 0; i < m_inventorySlots.Length; i++)
        {
            m_inventorySlots[i].Initialize(i,m_activateColor,m_deactivateColor);
        }
        UpdateGold();
    }

    public override void Open()
    {
        if (m_inventorySlots == null)
        {
            Initialize();
        }
        for(int i = 0; i < m_inventorySlots.Length; i++)
        {
            SlotUpdate(i);
        }

        Unemphasize();
        UpdateGold();
        background.SetActive(true);
    }

    public override void Close()
    {
        background.SetActive(false);
    }

    public  void SlotUpdate(int index) {
        m_inventorySlots[index].SlotUpdate(inventory.inventoryDatas[index]);
    }

    public void ShowItemDescription(int inventoryIndex)
    {
        m_itemDescriptionWindow.descriptionItem(inventory.inventoryDatas[inventoryIndex]);
        m_itemDescriptionWindowObject.SetActive(true);
        isShowDescription = true;
    }
    public void ShowItemDescription(ItemData item)
    {
        m_itemDescriptionWindow.descriptionItem(item);
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
    public bool EndMoving(int slotIndex) 
    {
        m_isMoving = false;
        if (m_allocatedSlot != -1 )
        {
            inventory.Swap(m_allocatedSlot, slotIndex);
            SlotUpdate(slotIndex);
            SlotUpdate(m_allocatedSlot);
            m_moveSlotImage.gameObject.SetActive(false);
            m_allocatedSlot = -1;
            return true;
            
        }
        else
        {
            m_allocatedSlot = -1;
            m_moveSlotImage.gameObject.SetActive(false);
            return false;
        }
    }
    public bool EndMoving(ItemData item)
    {
        m_isMoving = false;
        if (m_allocatedSlot != -1)
        {
            if(inventory.inventoryDatas[m_allocatedSlot].id == 0)
            {
                inventory.InsertItem(item, m_allocatedSlot);
                m_moveSlotImage.gameObject.SetActive(false);
                m_allocatedSlot = -1;
                return true;
            }
        }
        m_allocatedSlot = -1;
        m_moveSlotImage.gameObject.SetActive(false);
        return false;
    }

    public void SelectItem(int invenindex)
    {
        m_selectedItemIndex = invenindex;
        m_itemSelectWindowGO.transform.position = m_inventorySlots[invenindex].gameObject.transform.position + new Vector3(0, -35, 0);
        m_itemSelectWindowGO.SetActive(true);
        EmphasizeItem(invenindex);
        m_itemSeletWindow.Open(inventory.inventoryDatas[invenindex]);
    }
   
    public void DumpItemButton()
    {
        m_popUp.PopUp("버리기", inventory.inventoryDatas[m_selectedItemIndex], this.DumpItem);
    }
    public void DumpItem(ItemData item)
    {
        Unemphasize();
        if (!inventory.DeleteItem(item,m_selectedItemIndex))
        {
            warning.ShowWaring("소지중인 아이템 수량보다 많이 입력했습니다.");
            return;
            // 실패시 경고 알림.
        }
    }

    public void ItemDevideButton()
    {
        m_popUp.PopUp("나누기", inventory.inventoryDatas[m_selectedItemIndex], this.ItemDevide);
    }
    public void ItemDevide(ItemData item)
    {
        Unemphasize();
        //m_itemDevideWindw
        if(!inventory.DeleteItem(item,m_selectedItemIndex))
        {
            warning.ShowWaring("소지중인 아이템 수량보다 많이 입력했습니다.");
            return;
        }
        m_itemDevideWindow.OpenDevideWindow(item);

    }
 

    public void UpdateGold()
    {
        m_goldText.text = inventory.gold.ToString();
    }

    public void SortButton()
    {
        inventory.SortItem();

    }
    public void Sort()
    {
        for (int i = 0; i < m_inventorySlots.Length; i++)
        {
            SlotUpdate(i);
        }
    }

    // Emphasize 관련 부분
    #region
    public void EmphasizeItemCategory(Category category)
    {
        for(int  i = 0; i < m_inventorySlots.Length; i++)
        {
            if(inventory.inventoryDatas[i].category == category)
            {
                m_inventorySlots[i].Activate();
            }
            else
            {
                m_inventorySlots[i].Deactivate();
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
            if(item.invenIndex == inventoryindex)
            {
                item.Activate();
            }
            else
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


    public void Realse()
    {
        Unemphasize();
        m_itemDescriptionWindowObject.SetActive(false);

        m_popUpGO.SetActive(false);
        m_popUp.CleanInputText();

        m_itemSelectWindowGO.SetActive(false);
        
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
