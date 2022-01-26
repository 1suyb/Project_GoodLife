using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Tooltip("�κ��丮 ���� �׸��� ������Ʈ�� ������ �˴ϴ�.")]
    [SerializeField]
    private InventoryUI m_inventoryUI;
    public InventoryUI inventoryUI
    {
        get; set;
    }
    [Tooltip("ItemIcon�� ���� ���� ������Ʈ")]
    [SerializeField]
    private Image m_itemIconImage;
    //private GameObject itemIconObject;


    public Image itemIconImage
    {
        get => m_itemIconImage;
    }

    [Tooltip("ItemCount�ؽ�Ʈ�� ���� ���� ������Ʈ")]
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
    
    [Tooltip("������ �̵��ϴµ� �������ϴ� �ð�")]
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


    public void SetSlotData(ItemData inventoryitem, int _itemIndex)
    {
        
        if (m_slotData.inventoryIndex != -1)
        {
            m_slotData.itemCount = inventoryitem.itemCount;
        }
        else
        {
            m_slotData.itemicon = inventoryitem.itemSprite;
            m_slotData.itemCount = inventoryitem.itemCount;
            Debug.Log("���õ�����"+_itemIndex);
            m_slotData.inventoryIndex = _itemIndex;
            m_slotData.itemCategory = inventoryitem.category;
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
        //m_itemCountText = itemCountObject.GetComponent<Text>();
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
                m_currentPointDownTime = 0;
                m_inventoryUI.MovingItem(m_slotData.itemicon);
            }
        }
    }

    public void MouseEnter()
    {
        if (!isActivate)
        {
            Debug.Log("Ȱ��ȭ�ȵ�����!");
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
        isMoving = false;
        m_inventoryUI.EndMoving(this);
        
    }
    private void SelecctItem()
    {
        Debug.Log("SlectItem");
        Debug.Log("�����ۼ���");
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