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
    [SerializeField]
    private Color m_activateColor;
    private bool[] isActive = new bool[3];

    [SerializeField]
    private Warning waring;

    private ItemData _itemdata;
    private int _invenindex;


    public void Open(ItemData item)
    {
        Debug.Log("외않됨");
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
                images[0].color = m_activateColor;
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
            images[1].color = m_deactivateColor;

            isActive[2] = false;
            images[2].color = m_deactivateColor;
        }
        else
        {
            isActive[1] = true;
            images[1].color = m_activateColor;

            isActive[2] = true;
            images[2].color = m_activateColor;
        }

    }

    public void UseButtonClick()
    {
        if (!isActive[0])
        {
            waring.ShowWaring("사용가능한 아이템이 아닙니다.");
            return;
        }
        Debug.Log("UseItem");
        gameObject.SetActive(false);
    }
    public void DevideButtonClick()
    {
        if (!isActive[1])
        {
            waring.ShowWaring("이 아이템은 나눌 수 없습니다.");
            return;
        }
        invenUI.ItemDevideButton();
        gameObject.SetActive(false);
    }
    public void DeleteButtonClick()
    {
        if (!isActive[2])
        {
            waring.ShowWaring("이 아이템은 버릴 수 없습니다.");
            return;
        }
        invenUI.DumpItemButton();
        gameObject.SetActive(false);
    }

}
