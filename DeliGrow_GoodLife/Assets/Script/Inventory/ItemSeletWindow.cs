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


    private bool[] isActive;

    private ItemData _itemdata;


    public void Open(ItemData item)
    {
        _itemdata = item;
        switch (item.category)
        {
            case Category.TOOL:
            case Category.SEED:
                isActive[0] = false;
                break;
            case Category.CROP:
            case Category.FOOD:
                isActive[0] = true;
                break;
            case Category.MATERIAL:
            case Category.QUEST:
                isActive[0] = false;
                break;
            default:
                break;

        }
        if (item.category == Category.QUEST)
        {
            isActive[1] = false;
            isActive[2] = false;
        }

    }
    public void UseButtonClick()
    {
        Debug.Log("UseItem");
    }
    public void DevideButtonClick()
    {
        invenUI.ItemDevideButton();
    }
    public void DeleteButtonClick()
    {
        invenUI.DumpItemButton();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        for(int i = 0; i < isActive.Length; i++)
        {
            isActive[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
