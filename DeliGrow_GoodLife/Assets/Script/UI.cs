using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI : MonoBehaviour
{
    

    private bool IsPause = false;
    public virtual void Open()
    {
        UIManager.UIMANAGER.openUIs.Add(this);
        IsPause = true;
        Time.timeScale = 0;
    }
    public virtual void Close()
    {

        IsPause = false;
        Time.timeScale = 1;

    }

}
