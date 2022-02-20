using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI : MonoBehaviour
{
    [SerializeField]
    public UIManager uiManager;

    private bool IsPause = false;
    public virtual void Open()
    {
        uiManager.openUIs.Push(this);
        IsPause = true;
        Time.timeScale = 0;
    }
    public virtual void Close()
    {
        uiManager.openUIs.Pop();
        IsPause = false;
        Time.timeScale = 1;
    }

}
