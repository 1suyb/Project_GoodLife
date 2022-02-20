using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : UI
{
    [SerializeField]
    private GameObject shop;

    public override void Open()
    {
        base.Open();
        shop.SetActive(true);
    }

    public override void Close()
    {
        base.Close();
        shop.SetActive(false);
    }

}
