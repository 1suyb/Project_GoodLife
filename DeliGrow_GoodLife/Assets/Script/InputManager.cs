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
        if (Input.anyKey)
        {
            for (int i = 0; i < _actionkeys.Count; i++)
            {
                if (Input.GetKey(_actionkeys[i].keycode))
                {
                    _actionkeys[i].action.Invoke();
                }
            }
        }
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
    /*
    private void InitializeKey()
    {
        for (int i = 0; i < _shortcuts.Count; i++)
        {
            if ((int)_shortcuts[i].key < 97)
            {
                _shortcuts[i] = ChangeSmall(_shortcuts[i]);
            }
        }
    }*/
    /*
    private Shortcut ChangeSmall(Shortcut shortcut)
    {
        Shortcut rshortcut = new Shortcut();
        rshortcut.key = (char)((int)shortcut.key + TOSMALL);
        rshortcut.keycode = (KeyCode)shortcut.key;
        rshortcut.action = shortcut.action;
        return rshortcut;
    }
    */
    [Serializable]
    struct Shortcut
    {
        public char key;
        public KeyCode keycode;
        public UnityEvent action;
    }

}
