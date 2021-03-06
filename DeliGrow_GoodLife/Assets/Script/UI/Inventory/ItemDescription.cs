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
                itemCategory.text = "도구";
                break;
            case Category.SEED:
                itemCategory.text = "씨앗";
                break;
            case Category.CROP:
                itemCategory.text = "작물";
                break;
            case Category.FOOD:
                itemCategory.text = "음식";
                break;
            case Category.MATERIAL:
                itemCategory.text = "재료";
                break;
            case Category.QUEST:
                itemCategory.text = "퀘스트";
                break;
            default:
                break;

        }
        itemDescription.text = item.itemDescription;
    }
}
