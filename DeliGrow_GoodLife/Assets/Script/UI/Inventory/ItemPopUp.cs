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
    private ItemData _originItem;
    private ShopInventorySlot _slot;

    public delegate void YesFunctionPointer(ItemData a);
    public delegate void ThreeParamYesFunctionPointer(ItemData a, ItemData origin, ShopInventorySlot slot);
    public delegate void NOFunctionPointer();
    private YesFunctionPointer yesaction;
    private ThreeParamYesFunctionPointer tyesaction;
    private NOFunctionPointer noaction;

    public override void Open()
    {
        Debug.Log("열림");
        UIManager.UIMANAGER.openUIs.Add(this);
        //openUIs.Push(this);
    }
    public override void Close()
    {
        int count = UIManager.UIMANAGER.openUIs.Count - 1;
        UIManager.UIMANAGER.openUIs.RemoveAt(count);
        this.gameObject.SetActive(false);
        noaction();
    }
    public void ClosePopUp()
    {
        //openUIs.Pop();
        CleanInputText();
        _handlingItem = null;
        _originItem = null;
        _slot = null;
        this.gameObject.SetActive(false);
        yesaction = null;
        tyesaction = null;
        noaction = null;
    }
    public void PopUp(string title, ItemData item, YesFunctionPointer act)
    {
        Open();
        _originItem = item;
        _handlingItem = new ItemData(item.id, item.itemSprite, item.itemName, item.itemDescription, item.category, item.itemCount, item.itemPrice);
        this.gameObject.SetActive(true);
        _title.text = title;
        _description.text = DESCRIPTION;
        icon.sprite = _handlingItem.itemSprite;
        yesaction = act;
    }

    public void PopUp(string title, ItemData item, ShopInventorySlot slot, ThreeParamYesFunctionPointer act)
    {
        Open();
        _originItem = item;
        _handlingItem = new ItemData(item.id, item.itemSprite, item.itemName, item.itemDescription, item.category, item.itemCount, item.itemPrice);
        _slot = slot;
        this.gameObject.SetActive(true);
        _title.text = title;
        _description.text = DESCRIPTION;
        icon.sprite = _handlingItem.itemSprite;
        tyesaction = act;
    }

    public void PopUp(string title, ItemData item, YesFunctionPointer act,NOFunctionPointer noact)
    {
        PopUp(title, item, act);
        noaction = noact;
    }

    public void PopUp(string title, ItemData item, ShopInventorySlot slot, ThreeParamYesFunctionPointer act, NOFunctionPointer noact)
    {
        PopUp(title, item, slot, act);
        noaction = noact;
    }

    public void YesButton()
    {
        _handlingItem.itemCount = int.Parse(_input.text);
        this.gameObject.SetActive(false);
        if (yesaction != null)
            yesaction(_handlingItem);
        else
            tyesaction(_handlingItem, _originItem, _slot);
        ClosePopUp();
    }
    public void NoButton()
    {
        if (noaction != null)
        {
            noaction();
        }
        ClosePopUp();
    }
    private void CleanInputText()
    {
        _input.text = "";
    }

    public void OutofCount()
    {
        if (_input.text != "")
        {
            if(_input.text == "0")
            {
                _input.text = "1";
            }
            if(_input.text == "-")
            {
                _input.text = string.Empty;
            }
            if(int.Parse(_input.text) > 99)
            {
                _input.text = "99";
            }
            if (int.Parse(_input.text) > _handlingItem.itemCount)
            {
                _input.text = _handlingItem.itemCount.ToString();
            }
        }
    }
}
