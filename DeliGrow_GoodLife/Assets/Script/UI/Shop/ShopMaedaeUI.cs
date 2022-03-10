using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShopMaedaeUI : ShopUI
{
    [SerializeField]
    private ShopBasketUI shopBasketUI;
    [SerializeField]
    private TempData tempdata;
    [SerializeField]
    private GameObject popUp;

    private Slot[] basketSlots;
    

    public override void Open()
    {
        base.Open(1);
        shopBasketUI.Open();

        basketSlots = shopBasketUI.slots;

        for (int i=0; i<slots.Length; i++)
        {
              slots[i].SetSlotData(tempdata.item[i]);          
        }       
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

    public void PurchaseSingleItem(ItemData itemData)
    {
        // 전체 슬롯 반복문 돌리면서 아이템id 같으면 수량 추가. 없으면 빈 슬롯에 추가       
        for(int i = 0; i < basketSlots.Length; i++)
        {

            if( itemData.id == basketSlots[i]._itemData.id )
            {
                basketSlots[i].SetSlotData(1);
                return;
            }
        }
        for(int i = 0; i < basketSlots.Length; i++)
        {
            if( basketSlots[i]._itemData.itemCount == 0)
            {            
                basketSlots[i].SetSlotData(itemData.Clone());            
                return;
            }
        }
        Debug.Log("슬롯 꽉 참");

    }

    public void PurchaseItems(ItemData itemData)
    {

    }

    public void PopUpWindow(ItemData itemData)
    {
        popUp.GetComponent<ItemPopUp>().PopUp("구매 수량", itemData, PurchaseItems);
    }
   
   
}
