using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : UI
{
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private GameObject go_DescriptionWindow;

    private Slot[] slots;

    private bool isShowDescription = false;

    private shoptype _shopType;
    public void Open(shoptype type)
    {
        _shopType = type;
        Open();
        slots = this.gameObject.GetComponentsInChildren<Slot>();
        
    }

    public override void Open()
    {
        base.Open();
        shop.SetActive(true);
    }

    public void GetShopData()
    {
        /*
         샵테이블 파싱
         */

        /*
         * 아이템 테이블에서 아이템들 가져와서 슬롯에 넣기
         */

    }


    public override void Close()
    {
        base.Close();
        shop.SetActive(false);
    }

    public void ShowItemDescriptionWindow()
    {
        go_DescriptionWindow.SetActive(true);
        isShowDescription = true;
    }

    public void HideItemDescriptionWindow()
    {
        go_DescriptionWindow.SetActive(false);
        go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(0,1);
        isShowDescription = false;
    }

    void Update()
    {
        if(isShowDescription)
        {
            go_DescriptionWindow.transform.position = Input.mousePosition;
            if((Input.mousePosition.y - 300) < -10)
            {
                if ((Input.mousePosition.x + 200) > 1930)
                    go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(1,0);
                else
                    go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(0,0);
            }
            else
            {
                if ((Input.mousePosition.x + 200) > 1930)
                    go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(1,1);
                else
                    go_DescriptionWindow.GetComponent<RectTransform>().pivot = new Vector2(0,1);
            }
        }
    }

}
public enum shoptype
{
    TOOL,
    SEED,
    MATERIAL
}