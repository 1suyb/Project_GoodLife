using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [Tooltip("아이템 아이콘 스프라이트가 들어갈 게임오브젝트")]
    public GameObject itemiconObject;

    [Tooltip("아이템 개수를 표시해줄 텍스트")]
    public GameObject itemCntTextObject;
    
    [Tooltip("Deactivation상태일때 표시해줄 컬러값")]
    public int deactivateRGB;

    [Tooltip("Deactivateion상태일때 표시해줄 알파값")]
    public int deactivateAlpha;
    
    [Tooltip("아이템 설명창")]
    public GameObject itemDescriptionWindowObject;
    [Tooltip("아이템설명창 크기 절반")]
    public Vector3 itemDescritionWindowPosition;

    private Image itemiconImage;
    private TextMeshPro itemCntText;
    private int inventoryIndex;
    private int itemCnt = 0;
    private Vector4 deactivateColor;
    private Vector4 activateColor;
    private bool isActivate = true;
    private bool isMouseOn = false;
    

    public void ChangeItemSprite(Sprite itemsprite, int itemcount,int index){
        itemiconImage.sprite = itemsprite;
        itemCnt = itemcount;
        itemCntText.text = itemCnt.ToString();
        this.inventoryIndex = index;
    }
    public void MakeEmpty(){
        itemiconImage.sprite = null;
        itemiconImage.color = new Vector4(255,255,255,0);
        itemCnt = 0;
        inventoryIndex = -1;
    }
    public void AddItem(int itemcount){
        itemCnt += itemcount;
        itemCntText.text = itemCnt.ToString();
    }
    public void Deactivate(){
        this.GetComponent<Image>().color = deactivateColor;
        itemiconImage.color = deactivateColor;
        isActivate = false;
    }
    public void Activate(){
        this.GetComponent<Image>().color = activateColor;
        itemiconImage.color = activateColor;
        isActivate = true;
    }

    public void ShowItemDescription(){
        isMouseOn = true;
        
        itemDescriptionWindowObject.SetActive(true);

    }
    public void HideItemDescription(){
        isMouseOn = false;
        itemDescriptionWindowObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        itemiconImage = itemiconObject.GetComponent<Image>();
        itemCntText = itemCntTextObject.GetComponent<TextMeshPro>();
        deactivateColor = new Vector4(deactivateRGB,deactivateRGB,deactivateRGB,deactivateAlpha);
        activateColor = new Vector4(255,255,255,255);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMouseOn){
            itemDescriptionWindowObject.GetComponent<Transform>().position = Input.mousePosition+itemDescritionWindowPosition;
        }
        
    }
}
