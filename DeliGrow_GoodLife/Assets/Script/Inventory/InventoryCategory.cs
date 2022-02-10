using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryCategory : MonoBehaviour
{
    [Tooltip("해당카테고리")]
    [SerializeField]
    private Category m_category;
    public Category category
    {
        get => m_category;
    }
    [Tooltip("인벤토리 UI")]
    [SerializeField]
    private InventoryUI m_inventoryUI;
    [SerializeField]
    private Image m_image;
    private bool isActive = true;



    public void Deactivate()
    {
        isActive = false;
        m_image.color = m_inventoryUI.deactivateColor;
    }
    public void Activate()
    {
        isActive = true;
        m_image.color = m_inventoryUI.activateColor;
    }
    public  void ActivateCategroy()
    {
        m_inventoryUI.Unemphasize();
        m_inventoryUI.EmphasizeCategory(m_category);
        m_inventoryUI.EmphasizeItemCategory(m_category);
    }
}
