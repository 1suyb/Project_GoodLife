using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSeletWindow : MonoBehaviour
{

    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Text[] texts;
    [SerializeField]
    private InventoryUI invenUI;
    [SerializeField]
    private Color m_deactivateColor;

    private bool[] isActive = new bool[3];

    private ItemData _itemdata;
    private int _invenindex;


    public void Open(ItemData item)
    {
        Debug.Log("�ܾʵ�");
        this.gameObject.SetActive(true);
        _itemdata = item;
        switch (item.category)
        {
            case Category.TOOL:
            case Category.SEED:
                isActive[0] = false;
                images[0].color = m_deactivateColor;
                break;
            case Category.CROP:
            case Category.FOOD:
                isActive[0] = true;
                images[0].color = Color.white;
                break;
            case Category.MATERIAL:
            case Category.QUEST:
                isActive[0] = false;
                images[0].color = m_deactivateColor;
                break;
            default:
                break;

        }
        if (item.category == Category.QUEST)
        {
            isActive[1] = false;
            isActive[2] = false;
        }
        else
        {
            isActive[1] = true;
            isActive[2] = true;
        }

    }
    public void UseButtonClick()
    {
        if (!isActive[0])
        {
            return;
        }
        Debug.Log("UseItem");
        gameObject.SetActive(false);
    }
    public void DevideButtonClick()
    {
        if (!isActive[1])
        {
            return;
        }
        invenUI.ItemDevideButton();
        gameObject.SetActive(false);
    }
    public void DeleteButtonClick()
    {
        if (!isActive[2])
        {
            return;
        }
        invenUI.DumpItemButton();
        gameObject.SetActive(false);
    }

}
