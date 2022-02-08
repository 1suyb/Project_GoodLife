using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Warning : MonoBehaviour
{
    [Tooltip("��� ������ �� �ؽ�Ʈ�� �����ϼ���")]
    [SerializeField]
    Text m_text;

    public void ShowWaring(string text)
    {
        m_text.gameObject.SetActive(true);
        m_text.text = text;
        Invoke("HideWaring", 2f);
    }
    private void HideWaring()
    {
        m_text.gameObject.SetActive(false);
    }
}
