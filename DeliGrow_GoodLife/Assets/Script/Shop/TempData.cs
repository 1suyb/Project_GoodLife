using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TempShopData",menuName ="ScriptableObject")]
public class TempData : ScriptableObject

{   [SerializeField]
    public ItemData[] item = new ItemData[30];

}
