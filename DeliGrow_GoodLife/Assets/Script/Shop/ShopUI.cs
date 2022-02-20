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
         �����̺� �Ľ�
         */

        /*
         * ������ ���̺��� �����۵� �����ͼ� ���Կ� �ֱ�
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