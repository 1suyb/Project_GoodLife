using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{
    [Tooltip("제목")]
    [SerializeField]
    private Text _title;

    [Tooltip("설명")]
    [SerializeField]
    private Text _description;

    [Tooltip("인풋필드")]
    [SerializeField]
    private Text _input;

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

    public delegate void FunctionPointer(ItemData a);

    private FunctionPointer action;

    public void PopUp(string title, ItemData item, FunctionPointer act)
    {
        _handlingItem = new ItemData(item.id, item.itemSprite, item.itemName, item.itemDescription, item.category, item.itemCount);
        this.gameObject.SetActive(true);
        _title.text = title;
        _description.text = DESCRIPTION;
        icon.sprite = _handlingItem.itemSprite;
        action = act;
    }

    public void YesButton()
    {
        _handlingItem.itemCount = int.Parse(_input.text);
        this.gameObject.SetActive(false);
        action(_handlingItem);
        _handlingItem = null;
    }
    public void NoButton()
    {
        _handlingItem = null;
        this.gameObject.SetActive(false);
    }

}
