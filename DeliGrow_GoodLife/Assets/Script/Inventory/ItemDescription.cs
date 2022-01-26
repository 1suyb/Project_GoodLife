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
                itemCategory.text = "µµ±¸";
                break;
            case Category.SEED:
                itemCategory.text = "¾¾¾Ñ";
                break;
            case Category.CROP:
                itemCategory.text = "ÀÛ¹°";
                break;
            case Category.FOOD:
                itemCategory.text = "À½½Ä";
                break;
            case Category.MATERIAL:
                itemCategory.text = "Àç·á";
                break;
            case Category.QUEST:
                itemCategory.text = "Äù½ºÆ®";
                break;
            default:
                break;

        }
        itemDescription.text = item.itemDescription;
    }
}
