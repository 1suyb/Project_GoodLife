using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlotUI[] inventorySlots;
    public GameObject moveSlotItemSlot;
    public bool Is_MovingItemSlot;
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
        Category cate_hand;

        Sprite sprite_put;
        int itemcount_put;
        int invenindex_put;
        Category cate_put;

        handInSlot.GetSlotData(out sprite_hand, out itemcount_hand, out invenindex_hand, out cate_hand);
        putDownSlot.GetSlotData(out sprite_put, out itemcount_put, out invenindex_put, out cate_put);

        handInSlot.ChangeItemSprite(sprite_put,itemcount_put,invenindex_put,cate_put);
        putDownSlot.ChangeItemSprite(sprite_hand,itemcount_hand,invenindex_hand,cate_hand);
        
        EndMovingItemSlot();
    }
    public void EndMovingItemSlot(){
        moveSlotItemSlot.SetActive(false);
        handInSlot.EndMovingItemSlot();
        handInSlot = null;
        Is_MovingItemSlot = false;
    }

    public void EmphasizeCategoryItem(Category category){
        Sprite sp;
        int itemcnt;
        int itemindex;
        Category cate;
        foreach(var item in inventorySlots){
            item.GetSlotData(out sp, out itemcnt, out itemindex, out cate);
            if(cate == category){
                item.Activate();
            }
            else{
                item.Deactivate();
            }
        }
    }
    public void ReleaseEmphasizeCategoryItem(){
        foreach(var item in inventorySlots){
            item.Activate();
        }
    }

        // Start is called before the first frame update
    void Start()
    {
        moveSlotItemSlotTransform = moveSlotItemSlot.transform;
        inventorySlots = this.GetComponentsInChildren<InventorySlotUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Is_MovingItemSlot){
            moveSlotItemSlotTransform.position = Input.mousePosition;
            if(Input.GetMouseButtonUp(0)){
                EndMovingItemSlot();
            }
        }
    }

     
}