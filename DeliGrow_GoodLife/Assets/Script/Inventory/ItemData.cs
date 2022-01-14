using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    int id;
    string itemname;
    public static bool operator ==(ItemData op1, ItemData op2){
        return op1.id == op2.id;
    }
    public static bool operator !=(ItemData op1, ItemData op2){
        return !(op1 == op2);
    }

    public override bool Equals(object obj)
    {
       return this.id == ((ItemData)obj).id;
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return id;
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
