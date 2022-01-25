using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

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
    private TextMeshProUGUI m_itemCountText;
    //private GameObject itemCountObject;


    public TextMeshProUGUI itemCountText
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


    private Vector4 deactivateColor;
    private Vector4 activateColor;

    private bool isActivate = true;
    private bool isMoving = false;
    private bool isSelected = false;
    private bool isShowing = false;


    public void SetSlotData(ItemData item, int _itemIndex)
    {
        
        if (m_slotData.inventoryIndex != -1)
        {
            m_slotData.itemCount += item.itemCount;
        }
        else
        {
            m_slotData.itemicon = item.itemSprite;
            m_slotData.itemCount = item.itemCount;
            Debug.Log("셋팅데이터"+_itemIndex);
            m_slotData.inventoryIndex = _itemIndex;
            m_slotData.itemCategory = item.category;
        }
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
        if(slotData.inventoryIndex == -1)
        {
            m_itemCountText.color = Color.clear;
            m_itemIconImage.color = Color.clear;
        }
        m_itemIconImage.color = activateColor;
        isActivate = true;
    }

    public void Deactivate()
    {
        m_itemIconImage.color = deactivateColor;
        isActivate = false;
    }

    private void Awake()
    {
        m_slotData.inventoryIndex = -1;
    }
    private void OnEnable()
    {
        //m_itemCountText = itemCountObject.GetComponent<TextMeshProUGUI>();
        //m_itemIconImage = itemIconImage.GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InventoryUI invenui = this.GetComponentInParent<InventoryUI>();

        deactivateColor = invenui.deactivateColor;
        activateColor = invenui.activateColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            m_currentPointDownTime += Time.deltaTime;
            if(m_currentPointDownTime >= m_maxPointDownTime)
            {
                isSelected = false;
                isMoving = true;
                m_inventoryUI.MovingItem(m_slotData.itemicon);
            }
        }
    }

    private void OnMouseEnter()
    {
        if (!isActivate)
        {
            return;
        }
        if (isMoving)
        {
            AllocateInventoryUIPutDownSlot();
        }
        else
        {
            ShowItemDescription();
        }
    }
    private void OnMouseExit()
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
    private void OnMouseDown()
    {
        if(m_slotData.inventoryIndex != -1)
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
    private void OnMouseUp()
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
        m_inventoryUI.allocatedSlot = this;
    }
    private void ShowItemDescription()
    {
        m_inventoryUI.ShowItemDescription(slotData.inventoryIndex);
    }
    private void DeacllocateInventoryUIPutDownSlot()
    {
        m_inventoryUI.allocatedSlot = null;
    }
    private void HideItemDescription()
    {

        m_inventoryUI.allocatedSlot = null;
    }
    private void EndMoving()
    {
        m_inventoryUI.EndMoving(this);
        isMoving = false;
    }
    private void SelecctItem()
    {
        Debug.Log("아이템선택");
    }
    private void ItemUse()
    {

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