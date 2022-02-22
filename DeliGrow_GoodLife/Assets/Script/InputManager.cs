using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private UI inventoryUI;
    private bool isInvenOpen = false;

    private KeyCode _ESC;
    private KeyCode _inventoryKey;
    
    [Tooltip("인벤토리를 할당할 키입니다. 소문자로 입력하세요.")]
    [SerializeField]
    private char inventoryKey;
    

    const int TOSMALL = 32;

    // Start is called before the first frame update
    void Start()
    {
        InitializeKey();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_inventoryKey))
        {
            if (!isInvenOpen)
            {
                isInvenOpen = true;
                inventoryUI.Open();
            }
            else
            {
                isInvenOpen = false;
                inventoryUI.Close();
                Debug.Log("외않됨");
            }
        }
        if (Input.GetKeyDown(_ESC))
        {
            Debug.Log("이에쓰씨");
            int count = UIManager.UIMANAGER.openUIs.Count;
            Debug.Log(count);
            if(count <= 0)
            {
                return;
            }
            
            if (count > 0)
            {
                UIManager.UIMANAGER.openUIs[count - 1].Close();
            }
            
        }
    }
    private void InitializeKey()
    {
        _ESC = KeyCode.Escape;


        CheackNChangeSmall(ref inventoryKey);
        _inventoryKey = (KeyCode)inventoryKey;
        
    }
    private void CheackNChangeSmall(ref char key)
    {
        if ((int)key < 97)
        {
            key = (char)((int)key + TOSMALL);

        }
    }
}
