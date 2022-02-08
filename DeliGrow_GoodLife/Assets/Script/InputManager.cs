using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private UI inventoryUI;
    private bool isInvenOpen = false;

    private KeyCode m_inventoryKey;
    [Tooltip("�κ��丮�� �Ҵ��� Ű�Դϴ�. �ҹ��ڷ� �Է��ϼ���.")]
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
        if (Input.GetKeyDown(m_inventoryKey))
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
                Debug.Log("�ܾʵ�");
            }
        }
    }
    private void InitializeKey()
    {

        CheackNChangeSmall(ref inventoryKey);
        m_inventoryKey = (KeyCode)inventoryKey;
    }
    private void CheackNChangeSmall(ref char key)
    {
        if ((int)key < 97)
        {
            key = (char)((int)key + TOSMALL);

        }
    }
}
