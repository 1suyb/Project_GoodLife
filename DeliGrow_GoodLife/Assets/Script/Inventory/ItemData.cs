using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    // 아이템 ID
    [SerializeField]
    private int m_id;
    public int id
    {
        get => m_id;
        set => m_id = value;
    }
    [SerializeField]
    private Sprite m_itemSprite;
    
    public Sprite itemSprite
    {
        get => m_itemSprite;
        set => m_itemSprite = value;
    }
    
    // 아이템 이름
    [SerializeField]
    private string m_itemName;
    public string itemName
    {
        get => m_itemName;
        set => m_itemName = value;
    }

    // 아이템 설명
    [SerializeField]
    private string m_itemDescription;
    public string itemDescription
    {
        get => m_itemDescription;
        set => m_itemDescription = value;
    }

    // 아이템 카테고리
    [SerializeField]
    private Category m_category;
    public Category category
    {
        get => m_category;
        set => m_category = value;
    }

    [SerializeField]
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

    public ItemData(int id,Sprite sprite ,string itemName, string itemDescription, Category category, int itemcount)
    {
        m_id = id;
        m_itemSprite = sprite;
        m_itemName = itemName;
        m_itemDescription = itemDescription;
        m_category = category;
        m_itemCount = itemcount;
    }
    public ItemData Clone()
    {
        return new ItemData(this.m_id, this.m_itemSprite, this.m_itemName, this.m_itemDescription, this.m_category, this.m_itemCount);
    }
    public bool IsEqual(ItemData val)
    {
        
        if(this.id == val.id)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator >(ItemData val1,ItemData val2)
    {
        return val1.id > val2.id;
    }
    public static bool operator <(ItemData val1, ItemData val2)
    {
        return val1.id < val2.id;
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
