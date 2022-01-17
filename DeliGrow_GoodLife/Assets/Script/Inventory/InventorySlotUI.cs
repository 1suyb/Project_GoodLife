using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [Tooltip("인벤토리 총괄 스크립트")]
    public Inventory inventory;
    [Tooltip("부모의 인벤토리 UI 스크립트")]
    public InventoryUI Invnetory_UI;
    [Tooltip("아이템 아이콘 스프라이트가 들어갈 게임오브젝트")]
    public GameObject Item_icon_object;

    [Tooltip("아이템 개수를 표시해줄 텍스트")]
    public GameObject Item_count_text_object;
    
    [Tooltip("Deactivation상태일때 표시해줄 컬러값")]
    public int Deactivate_RGB;

    [Tooltip("Deactivateion상태일때 표시해줄 알파값")]
    public int Deactivate_alpha;
    
    [Tooltip("아이템 설명창")]
    public GameObject Item_description_window_object;
    [Tooltip("아이템설명창 크기 절반")]
    public Vector3 Item_description_window_position;
    [Tooltip("슬롯 ")]
    public float Max_mouse_down_time;

    public SlotData itemdata;
    
    private Image item_icon_image;
    private TextMeshPro item_count_text;
   
    private Vector4 deactivate_color;
    private Vector4 activate_color;
    private bool is_active = true;
    private bool is_mouseOn = false;
    private bool is_beginPointDown = false;
    private float current_mouse_down_time = 0f;
    private bool is_movingItemSlot = false;
    // 슬롯 데이터를 주는 함수
    public void GetSlotData(out Sprite sprite, out int itencount, out int index, out Category category){
        sprite = itemdata.itemicon_sprite;
        itencount = itemdata.item_cnt;
        index = itemdata.inventory_index;
        category = itemdata.category;
    }
    
    // 슬롯의 데이터들과 스프라이트들을 변경하는 함수
    public void ChangeItemSprite(Sprite itemsprite, int itemcount,int index, Category category){
        if(itemdata.inventory_index == -1){
            item_icon_image.color = activate_color;
        }
        itemdata.itemicon_sprite = itemsprite;
        item_icon_image.sprite = itemdata.itemicon_sprite;

        itemdata.item_cnt = itemcount;

        item_count_text.text = itemdata.item_cnt.ToString();
        itemdata.inventory_index = index;

        itemdata.category = category;
    }
    // 슬롯을 비우는 함수
    public void MakeEmpty(){
        item_icon_image.sprite = null;
        item_icon_image.color = new Vector4(255,255,255,0);

        itemdata.item_cnt = 0;
        itemdata.inventory_index = -1;
        itemdata.category = Category.none;
    }

    // 슬롯에 있는 아이템을 추가하는 함수
    public void AddItem(int itemcount){
        itemdata.item_cnt += itemcount;
        if(itemdata.item_cnt <= 0){
            MakeEmpty();
            return;
        }
        item_count_text.text = itemdata.item_cnt.ToString();
    }
    // deactivate상태로 만드는 함수
    public void Deactivate(){
        this.GetComponent<Image>().color = deactivate_color;
        if(itemdata.inventory_index>-1){
            item_icon_image.color = deactivate_color;
        }
        
        is_active = false;
    }
    // deactivate상태를 해제하는 함수
    public void Activate(){
        this.GetComponent<Image>().color = activate_color;
        item_icon_image.color = activate_color;
        is_active = true;
    }
    // 포인터가 위로 오버레이 됬을 때 설명이 보이는 함수
    public void ShowItemDescription(){
        is_mouseOn = true;
        
        Item_description_window_object.SetActive(true);

    }
    // 포인터가 밖으로 나갔을때 설명이 사라지는 함수
    public void HideItemDescription(){
        is_mouseOn = false;
        Item_description_window_object.SetActive(false);
    }

    public void BeginPointDown(){
        if(Input.GetMouseButtonDown(0)){
            is_beginPointDown = true;
        }
        if(Input.GetMouseButtonDown(1)){
            inventory.UseItem();
        }
    }

    public void PointUp(){
        if(is_beginPointDown&& Input.GetMouseButtonUp(0)){
            SelectItem();
            is_beginPointDown = false;
        }
        if(Invnetory_UI.Is_MovingItemSlot && Input.GetMouseButtonUp(0)){
            Invnetory_UI.SwapItemSlot(this);
        }
    }

    public void SelectItem(){
        Debug.Log("아이템 선택됫음 ");
    }

    public void EndMovingItemSlot(){
        Debug.Log("call endmovingitemslot");
        is_movingItemSlot = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        item_icon_image = Item_icon_object.GetComponent<Image>();
        item_count_text = Item_count_text_object.GetComponent<TextMeshPro>();
        deactivate_color = new Vector4(Deactivate_RGB,Deactivate_RGB,Deactivate_RGB,Deactivate_alpha);
        activate_color = new Vector4(255,255,255,255);
    }

    // Update is called once per frame
    void Update()
    {
        if(is_mouseOn){
            Item_description_window_object.GetComponent<Transform>().position = Input.mousePosition+Item_description_window_position;
        }
        if(is_beginPointDown && !is_movingItemSlot){
            current_mouse_down_time +=Time.deltaTime;
        }
        if(is_beginPointDown && current_mouse_down_time>=Max_mouse_down_time){
            is_beginPointDown = false;
            is_movingItemSlot = true;
            current_mouse_down_time = 0f;
            Invnetory_UI.StartMoveItemIcon(this);
        }
    }
    public static bool operator ==(InventorySlotUI op1, InventorySlotUI op2){
        return op1.itemdata.inventory_index == op2.itemdata.inventory_index;
    }
    public static bool operator !=(InventorySlotUI op1, InventorySlotUI op2){
        return !(op1 == op2);
    }

    public override bool Equals(object obj)
    {
       return this.itemdata.inventory_index == ((InventorySlotUI)obj).itemdata.inventory_index;
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return itemdata.inventory_index;
    }
}
public struct SlotData{
    public Sprite itemicon_sprite;
    public int inventory_index;
    public int item_cnt;
    public Category category;
}