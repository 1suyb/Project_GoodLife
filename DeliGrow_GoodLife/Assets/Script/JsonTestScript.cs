using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTestScript : MonoBehaviour
{
    public void but()
    {
        List<Item> item = JsonUtil.ItemDeserialize(DataType.Item);
        Debug.Log(item[0].ID);
    }
}
