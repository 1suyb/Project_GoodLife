using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : UI
{
    public override bool Open()
    {
        /* 
         전체 슬롯 초기화
         */
        this.gameObject.SetActive(true);
        return true;
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
