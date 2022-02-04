using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private UI inventoryUI;

    [SerializeField]
    private KeyCode m_inventoryKey;
    // Start is called before the first frame update
    void Start()
    {
        m_inventoryKey = KeyCode.I;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(m_inventoryKey))
        {
            inventoryUI.Open();
        }
    }
}
