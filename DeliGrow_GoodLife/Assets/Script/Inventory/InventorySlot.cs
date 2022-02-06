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

    [Tooltip("아이템 이동하는데 눌러야하는 시간")]
    [SerializeField]
    private float m_maxPointDownTime;
    public float maxPointDownTime
    {
        get;set;
    }
    private float m_currentPointDownTime;

    private Vector4 m_activateColor;
    private Vector4 m_deactivateColor;

    private int m_invenindex;
    public int invenIndex
    {
        get => m_invenindex;
    }

    private ItemData m_item;

    private bool isActivate = true;
    private bool isMoving = false;
    private bool isSelected = false;
    private bool isShowing = false;

    
    public void Initialize(int index,Vector4 activatecolor,Vector4 deactivateclor)
    {
        m_invenindex = index;
        m_activateColor = activatecolor;
        m_deactivateColor = deactivateclor;
    }

    public void SlotUpdate(ItemData item)
    {
        m_item = item;
        if(item.id == 0)
        {
            m_itemIconImage.sprite = null;
            m_itemIconImage.color = Color.clear;
            m_itemCountText.text = " ";
            isActivate = false;
            return;
        }
        m_itemIconImage.sprite = item.itemSprite;
        m_itemIconImage.color = m_activateColor;
        m_itemCountText.text = item.itemCount.ToString();
        isActivate = true;

    }

    public void Activate()
    {
        if(itemIconImage.sprite != null)
        {
            isActivate = true;
            m_itemIconImage.color = m_activateColor;
        }
    }

    public void Deactivate()
    {
        if (m_itemIconImage.sprite != null)
        {
            m_itemIconImage.color = m_deactivateColor;
            isActivate = false;
        }
        
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
                m_inventoryUI.MovingItem(m_item.itemSprite);
            }
        }
    }

    public void MouseEnter()
    {
        
        if (m_inventoryUI.isMoving == true)
        {
            AllocateInventoryUIPutDownSlot();
            return;
        }
        if (!isActivate)
        {
            return;
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
        if(!isActivate)
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
        m_inventoryUI.allocatedSlot = m_invenindex;
    }
    private void ShowItemDescription()
    {
        Debug.Log("ShowItemDescription");
        m_inventoryUI.ShowItemDescription(m_invenindex);
    }
    private void DeacllocateInventoryUIPutDownSlot()
    {
        Debug.Log("DeallocateInventoryUIPutDownSlot");
        m_inventoryUI.allocatedSlot = -1;
    }
    private void HideItemDescription()
    {
        Debug.Log("HideItemdescription");
        m_inventoryUI.HideItemDescription();
    }
    private void EndMoving()
    {
        isMoving = false;
        m_inventoryUI.EndMoving(invenIndex);
    }
    private void SelecctItem()
    {
        m_inventoryUI.SelectItem(m_invenindex);
        Debug.Log("SlectItem");
        Debug.Log("아이템선택");
        isSelected = false;
    }
    private void ItemUse()
    {

    }
    
}
