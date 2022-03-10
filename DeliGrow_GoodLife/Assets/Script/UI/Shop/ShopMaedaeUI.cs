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
         �����̺� �Ľ�
         */

        /*
         * ������ ���̺��� �����۵� �����ͼ� ���Կ� �ֱ�
         */

    }

    public void PurchaseSingleItem(ItemData itemData)
    {
        // ��ü ���� �ݺ��� �����鼭 ������id ������ ���� �߰�. ������ �� ���Կ� �߰�       
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
        Debug.Log("���� �� ��");

    }

    public void PurchaseItems(ItemData itemData)
    {

    }

    public void PopUpWindow(ItemData itemData)
    {
        popUp.GetComponent<ItemPopUp>().PopUp("���� ����", itemData, PurchaseItems);
    }
   
   
}
