using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShopUI : UI
{
    [SerializeField]
    private GameObject shop;
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private TempData tempdata;
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
        for(int i=0; i<slots.Length; i++)
        {
            slots[i].SetSlotData(tempdata.item[i].itemSprite, tempdata.item[i].itemCount, tempdata.item[i].category);
        }
        
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
    public void LoadJsonData(string path)
    {
        System.IO.FileInfo loadfile = new System.IO.FileInfo(path);
        if (loadfile.Exists == false)
        {
            Debug.LogError("파일 없음");
            return;
        }
        string JsonData = File.ReadAllText(loadfile.FullName);

        Debug.Log(JsonData);

        TestItemData data = JsonUtility.FromJson<TestItemData>(JsonData);
        Debug.Log(data.ID);

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

[System.Serializable]
public class TestItemData
{
    public string ID;
    public string korean;
    public string Name;
    public string Main_type;
    public string Sub_type;
    public string Grade;
    public string Price_type;
    public string Purchase_price;
    public string Sell_price;
    public string intOption_id_1;
    public string Option_value_1;
    public string Option_id_2;
    public string Option_value_2;
    public string Cool_time;

}
public enum shoptype
{
    TOOL,
    SEED,
    MATERIAL
}