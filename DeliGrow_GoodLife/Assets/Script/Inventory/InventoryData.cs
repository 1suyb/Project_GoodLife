using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryData : MonoBehaviour
{
    private ItemData[] inventory = new ItemData[30];
    private const int INVENSIZE = 30;

    public void PutInItem(ItemData item){
        for(int i = 0;i<INVENSIZE;i++){
            if(inventory[i] == item){
                inventory[i].count += item.count;
                return ;
            }
            else if(inventory[i]==null){
                inventory[i] = item.clone();
                return ;
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}