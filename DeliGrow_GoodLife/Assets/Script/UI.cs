using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private bool IsPause = false;
    public virtual void Open()
    {
        IsPause = true;
        Time.timeScale = 0;
    }
    public virtual void Close()
    {
        IsPause = false;
        Time.timeScale = 1;
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
