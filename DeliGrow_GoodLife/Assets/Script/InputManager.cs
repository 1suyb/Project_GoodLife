using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private List<Shortcut> _actionkeys = new List<Shortcut>();
    [SerializeField]
    private List<Shortcut> _shortcuts = new List<Shortcut>();
    const int TOSMALL = 32;
    
    // Start is called before the first frame update
    void Start()
    {
        //InitializeKey();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(_actionkeys.Count <= 0)
        {
            return;
        }
        if (Input.GetKey(_actionkeys[0].keycode))
        {
            _actionkeys[0].action.Invoke();
        }
        if (Input.GetKey(_actionkeys[1].keycode))
        {
            _actionkeys[1].action.Invoke();
        }
        if (Input.GetKey(_actionkeys[2].keycode))
        {
            _actionkeys[2].action.Invoke();
        }
        if (Input.GetKey(_actionkeys[3].keycode))
        {
            _actionkeys[3].action.Invoke();
        }
        //if (Input.anyKey)
        //{
        //    for (int i = 0; i < _actionkeys.Count; i++)
        //    {
        //        if (Input.GetKey(_actionkeys[i].keycode))
        //        {
        //            _actionkeys[i].action.Invoke();
        //        }
        //    }
        //}
    }
    void Update()
    {
        
        if (Input.anyKey)
        {
            for (int i = 0; i < _shortcuts.Count; i++)
            {
                if (Input.GetKey(_shortcuts[i].keycode))
                {
                    _shortcuts[i].action.Invoke();
                }
            }
        }
        
    }
    [Serializable]
    struct Shortcut
    {
        public char key;
        public KeyCode keycode;
        public UnityEvent action;
    }

}
