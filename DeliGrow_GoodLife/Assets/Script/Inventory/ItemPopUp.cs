using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{
    [Tooltip("����")]
    [SerializeField]
    private Text _title;

    [Tooltip("����")]
    [SerializeField]
    private Text _description;

    [Tooltip("��ǲ�ʵ�")]
    [SerializeField]
    private InputField _input;
    private Text _text;

    [Tooltip("Ȯ�ι�ư")]
    [SerializeField]
    private GameObject _yesButton;

    [Tooltip("��ҹ�ư")]
    [SerializeField]
    private GameObject _noButton;

    [Tooltip("������")]
    [SerializeField]
    private Image icon;


    private readonly string DESCRIPTION = "������ �Է��ϼ���";

    private ItemData _handlingItem;

    public delegate void YesFunctionPointer(ItemData a);
    public delegate void NOFunctionPointer();
    private YesFunctionPointer yesaction;
    private NOFunctionPointer noaction;

    public void PopUp(string title, ItemData item, YesFunctionPointer act)
    {
        _handlingItem = new ItemData(item.id, item.itemSprite, item.itemName, item.itemDescription, item.category, item.itemCount);
        this.gameObject.SetActive(true);
        _title.text = title;
        _description.text = DESCRIPTION;
        icon.sprite = _handlingItem.itemSprite;
        yesaction = act;
    }
    public void PopUp(string title, ItemData item, YesFunctionPointer act,NOFunctionPointer noact)
    {
        _handlingItem = new ItemData(item.id, item.itemSprite, item.itemName, item.itemDescription, item.category, item.itemCount);
        this.gameObject.SetActive(true);
        _title.text = title;
        _description.text = DESCRIPTION;
        icon.sprite = _handlingItem.itemSprite;
        yesaction = act;
        noaction = noact;

    }

     public void YesButton()
    {
        _handlingItem.itemCount = int.Parse(_input.text);
        this.gameObject.SetActive(false);
        CleanInputText();
        yesaction(_handlingItem);
        _handlingItem = null;

    }
    public void NoButton()
    {
        CleanInputText();
        _handlingItem = null;
        this.gameObject.SetActive(false);
        if (noaction != null)
        {
            noaction();
        }
        
    }
    private void CleanInputText()
    {
        _input.text = "";
    }

    public void OutofCount()
    {
        if (_input.text != "")
        {
            if(_input.text == "00")
            {
                _input.text = "0";
            }
            if(_input.text.Length>=2&&_input.text[0] == '0')
            {
                _input.text = _input.text[1].ToString();
            }
            if (int.Parse(_input.text) > _handlingItem.itemCount)
            {
                _input.text = _handlingItem.itemCount.ToString();
            }
            else if (int.Parse(_input.text) < 0)
            {
                _input.text = "0";
            }
        }
    }
}
