using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : UI
{
    [Tooltip("제목")]
    [SerializeField]
    private Text _title;

    [Tooltip("설명")]
    [SerializeField]
    private Text _description;

    [Tooltip("인풋필드")]
    [SerializeField]
    private InputField _input;
    private Text _text;

    [Tooltip("확인버튼")]
    [SerializeField]
    private GameObject _yesButton;

    [Tooltip("취소버튼")]
    [SerializeField]
    private GameObject _noButton;

    [Tooltip("아이콘")]
    [SerializeField]
    private Image icon;


    private readonly string DESCRIPTION = "수량을 입력하세요";

    private ItemData _handlingItem;

    public delegate void YesFunctionPointer(ItemData a);
    public delegate void NOFunctionPointer();
    private YesFunctionPointer yesaction;
    private NOFunctionPointer noaction;

    public override void Open()
    {
        //openUIs.Push(this);
    }
    public override void Close()
    {
        noaction();
    }
    public void ClosePopUp()
    {
        //openUIs.Pop();
        CleanInputText();
        _handlingItem = null;
        this.gameObject.SetActive(false);
        yesaction = null;
        noaction = null;
    }
    public void PopUp(string title, ItemData item, YesFunctionPointer act)
    {
        Open();
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
        yesaction(_handlingItem);
        ClosePopUp();
    }
    public void NoButton()
    {
        ClosePopUp();
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
