using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public Inventory inven;
    public void InputItem()
    {
        ItemData item = new ItemData(1, null,"������", "�����ۼ���", Category.TOOL, 4);
        Debug.Log(inven.PutInItem(item));
    }
    public void InputItem2()
    {
        ItemData item = new ItemData(2, null,"������2", "�����ۼ���", Category.QUEST, 4);
        Debug.Log(inven.PutInItem(item));
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
