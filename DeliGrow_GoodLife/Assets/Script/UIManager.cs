using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager UIMANAGER;
    public List<UI> openUIs = new List<UI>();

    public void Awake()
    {
        if(UIMANAGER == null)
        {
            UIMANAGER = this;
        }
    }

    // public void CloseLastUI()
    // {
    //     int count = openUIs.Count;
    //     if(count>0)
    //         openUIs.RemoveAt(count - 1);
    // }
    // public void CloseAllUI()
    // {
    //     int count = openUIs.Count;
    //     if (count > 0)
    //     {
    //         openUIs.Clear();
    //     }
    // }
}
