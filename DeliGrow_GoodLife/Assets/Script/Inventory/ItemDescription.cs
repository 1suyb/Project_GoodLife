using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDescription : MonoBehaviour
{
    public Text itemName;
    public Text itemCategory;
    public Text itemDescription;
    public void descriptionItem(ItemData item)
    {
        itemName.text = item.itemName;
        switch (item.category)
        {
            case Category.TOOL:
                itemCategory.text = "����";
                break;
            case Category.SEED:
                itemCategory.text = "����";
                break;
            case Category.CROP:
                itemCategory.text = "�۹�";
                break;
            case Category.FOOD:
                itemCategory.text = "����";
                break;
            case Category.MATERIAL:
                itemCategory.text = "���";
                break;
            case Category.QUEST:
                itemCategory.text = "����Ʈ";
                break;
            default:
                break;

        }
        itemDescription.text = item.itemDescription;
    }
}
