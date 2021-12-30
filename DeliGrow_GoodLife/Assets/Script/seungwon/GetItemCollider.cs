using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("CanBePickedUp"))
        {
            Debug.Log("col");
            col.gameObject.SetActive(false);
        }
    }
}
