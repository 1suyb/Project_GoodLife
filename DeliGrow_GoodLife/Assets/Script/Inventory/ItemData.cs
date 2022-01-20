using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    // 아이템 ID
    private int m_id;
    public int id
    {
        get => m_id;
        set => m_id = value;
    }

    // 아이템 이름
    private string m_itemName;
    public string itemName
    {
        get => m_itemName;
        set => m_itemName = value;
    }

    // 아이템 설명
    private string m_itemDescription;
    public string itemDescription
    {
        get => m_itemDescription;
        set => m_itemDescription = value;
    }

    // 아이템 카테고리
    private Category m_category;
    public Category category
    {
        get => m_category;
        set => m_category = value;
    }

    private int m_itemCount;
    public int itemCount
    {
        get => m_itemCount;
        set
        {
            if (value > 0)
            {
                m_itemCount = value;
            }
            else
            {
                m_itemCount = 0;
            }
        }
    }

    public ItemData(int id, string itemName, string itemDescription, Category category, int itemcount)
    {
        m_id = id;
        m_itemName = itemName;
        m_itemDescription = itemDescription;
        m_category = category;
        m_itemCount = itemcount;
    }

}

public enum Category
{
    TOOL = 1,
    SEED = 2,
    CROP = 3,
    FOOD = 4,
    MATERIAL = 5,
    QUEST = 6,
    NONE = -1

}
