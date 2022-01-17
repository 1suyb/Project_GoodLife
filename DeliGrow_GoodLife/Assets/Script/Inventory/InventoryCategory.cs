using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCategory : MonoBehaviour
{
    [Tooltip("이 UI의 담당 카테고리")]
    public Category thisCategory;
    [Tooltip("인벤토리 UI총괄 오브젝트")]
    public GameObject inventory;


    public void SelectedCategory(){
        inventory.GetComponent<InventoryUI>().EmphasizeCategoryItem(thisCategory);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum Category{
        tool = 1,
        seed =2,
        crop = 3,
        cook = 4,
        material = 5,
        quetst = 6,
        none = -1
    }