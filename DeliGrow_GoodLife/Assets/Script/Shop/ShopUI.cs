using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : UI
{

    [SerializeField]
    protected GameObject panel;
    [SerializeField]
    protected Inventory inventory;
    [SerializeField]
    protected GameObject go_DescriptionWindow;

    protected Slot[] slots;

    protected bool isShowDescription = false;

    protected ItemDescription itemDescription;


    public virtual void Open(int q)
    {
        // _shopType = type;
        itemDescription = go_DescriptionWindow.GetComponent<ItemDescription>();
        panel.SetActive(true);
       
    
    }

    public void ShowItemDescriptionWindow(ItemData itemData)
    {
        itemDescription.descriptionItem(itemData);
        go_DescriptionWindow.SetActive(true);
        isShowDescription = true;
    }

    public void HideItemDescriptionWindow()
    {
        go_DescriptionWindow.SetActive(false);
        go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
        isShowDescription = false;
    }

    void Update()
    {
        if (isShowDescription)
        {
            go_DescriptionWindow.transform.position = Input.mousePosition;
            if ((Input.mousePosition.y - 300) < -10)
            {
                if ((Input.mousePosition.x + 200) > 1930)
                    go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(1, 0);
                else
                    go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
            }
            else
            {
                if ((Input.mousePosition.x + 200) > 1930)
                    go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
                else
                    go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            }
        }
    }

}


