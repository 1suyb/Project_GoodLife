using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShopMaedaeUI : ShopUI
{
    [SerializeField]
    private TempData tempdata;

    public override void Open(int q)
    {
        base.Open();
        slots = this.gameObject.GetComponentsInChildren<Slot>();

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
   
   
}
