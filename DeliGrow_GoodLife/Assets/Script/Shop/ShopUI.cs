using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : UI
{
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private Inventory inventory;

    private Slot[] slots;

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

}
public enum shoptype
{
    TOOL,
    SEED,
    MATERIAL
}