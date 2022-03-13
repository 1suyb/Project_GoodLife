using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ShopMaedaeUI : ShopUI
{
    [SerializeField]
    private ShopBasketUI shopBasketUI;
    [SerializeField]
    private TempData tempdata;
    [SerializeField]
    private GameObject popUp;
    [SerializeField]
    private Text amount;
    [SerializeField]
    private Text balance;
    [SerializeField]
    private Text confirmButtonText;


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
        for(int i = 0; i < basketSlots.Length; i++)
        {
            if( itemData.id == basketSlots[i]._itemData.id )
            {
                basketSlots[i].SetSlotData(itemData.itemCount);
                setIsPopedFalse();
                return;
            }
        }
        for(int i = 0; i < basketSlots.Length; i++)
        {
            if( basketSlots[i]._itemData.itemCount == 0 )
            {
                basketSlots[i].SetSlotData(itemData.Clone());
                setIsPopedFalse();
                return;
            }
        }
        Debug.Log("���� �� ��");
    }

    public void PopUpWindow(ItemData itemData)
    {
        setIsPopedTrue();
        popUp.GetComponent<ItemPopUp>().PopUp("���� ����", itemData, PurchaseItems, setIsPopedFalse);
    }

    public void setIsPopedFalse()
    {
        isPoped = false;
        shopBasketUI.setIsPopedFalse();
    }

    public void setIsPopedTrue()
    {
        isPoped = true;
        shopBasketUI.setIsPopedTrue();
    }

    public void setSellMode()
    {
        if (shopBasketUI.isPurchase == false) return;
        this.gameObject.SetActive(false);
        shopBasketUI.clearBasket();
        amount.text = "�Ǹ� �ݾ�";
        balance.text = "�Ǹ� �� �ܾ�";
        confirmButtonText.text = "�Ǹ��ϱ�";
        shopBasketUI.isPurchase = false;

    }

    public void setPurchaseMode()
    {
        if (shopBasketUI.isPurchase == true) return;
        this.gameObject.SetActive(true);
        shopBasketUI.clearBasket();
        amount.text = "���� �ݾ�";
        balance.text = "���� �� �ܾ�";
        confirmButtonText.text = "�����ϱ�";
        shopBasketUI.isPurchase = true;
    }
   
   
}
