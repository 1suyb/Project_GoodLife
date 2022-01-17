using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject moveSlotItemSlot;
    private bool Is_MovingItemSlot;
    public InventorySlotUI handInSlot;
    private Transform moveSlotItemSlotTransform;

    
    public void StartMoveItemIcon(InventorySlotUI slot){
        Is_MovingItemSlot = true;
        moveSlotItemSlot.SetActive(true);
        handInSlot = slot;
    }
    
    public void SwapItemSlot(InventorySlotUI putDownSlot){
        if(handInSlot == putDownSlot){
            return ;
        }
        Sprite sprite_hand;
        int itemcount_hand;
        int invenindex_hand;

        Sprite sprite_put;
        int itemcount_put;
        int invenindex_put;

        handInSlot.GetSlotData(out sprite_hand, out itemcount_hand, out invenindex_hand);
        putDownSlot.GetSlotData(out sprite_put, out itemcount_put, out invenindex_put);

        handInSlot.ChangeItemSprite(sprite_put,itemcount_put,invenindex_put);
        putDownSlot.ChangeItemSprite(sprite_hand,itemcount_hand,invenindex_hand);
        
        moveSlotItemSlot.SetActive(false);
    }
        // Start is called before the first frame update
    void Start()
    {
        moveSlotItemSlotTransform = moveSlotItemSlot.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Is_MovingItemSlot){
            moveSlotItemSlotTransform.position = Input.mousePosition;
            if(Input.GetMouseButtonUp(0)){
                /* 아무것도 아닌 곳에 마우스 드래그를 놨을 경우 
                     그냥 이제 무브슬롯아이템슬롯을 셋엑티브페일해줌*/
            }
        }
    }

     
}