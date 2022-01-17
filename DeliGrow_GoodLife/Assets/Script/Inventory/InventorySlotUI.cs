using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
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

    
    private Image item_icon_image;
    private TextMeshPro item_count_text;
    private Sprite itemicon_sprite;
    private int inventory_index;
    private int item_cnt = 0;
    private Vector4 deactivate_color;
    private Vector4 activate_color;
    private bool is_active = true;
    private bool is_mouseOn = false;
    private bool is_beginPointDown = false;
    private float current_mouse_down_time = 0f;
    private bool is_movingItemSlot = false;

    public void GetSlotData(out Sprite sprite, out int itencount, out int index){
        sprite = item_icon_image.sprite;
        itencount = item_cnt;
        index = inventory_index;
    }
    public void ChangeItemSprite(Sprite itemsprite, int itemcount,int index){
        item_icon_image.sprite = itemsprite;
        item_cnt = itemcount;
        item_count_text.text = item_cnt.ToString();
        this.inventory_index = index;
    }
    public void MakeEmpty(){
        item_icon_image.sprite = null;
        item_icon_image.color = new Vector4(255,255,255,0);
        item_cnt = 0;
        inventory_index = -1;
    }
    public void AddItem(int itemcount){
        item_cnt += itemcount;
        item_count_text.text = item_cnt.ToString();
    }
    public void Deactivate(){
        this.GetComponent<Image>().color = deactivate_color;
        item_icon_image.color = deactivate_color;
        is_active = false;
    }
    public void Activate(){
        this.GetComponent<Image>().color = activate_color;
        item_icon_image.color = activate_color;
        is_active = true;
    }

    public void ShowItemDescription(){
        is_mouseOn = true;
        
        Item_description_window_object.SetActive(true);

    }
    public void HideItemDescription(){
        is_mouseOn = false;
        Item_description_window_object.SetActive(false);
    }
    public void BeginPointDown(){
        is_beginPointDown = true;
    }
    // 슬롯 체인지 등으로 이름 바꾸기
    public void EndMovingItemSlot(){
        // 인벤토리 유아이에서 지금 슬롯옮기는 중인지 체크
        Invnetory_UI.SwapItemSlot(this);
        
    }
    // 엔드무빙아이템 슬롯 함수를 만들어서
    // 자기가 움직이는 중이라는 체크를 해제
    

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
        return op1.inventory_index == op2.inventory_index;
    }
    public static bool operator !=(InventorySlotUI op1, InventorySlotUI op2){
        return !(op1 == op2);
    }

    public override bool Equals(object obj)
    {
       return this.inventory_index == ((InventorySlotUI)obj).inventory_index;
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return inventory_index;
    }
}
