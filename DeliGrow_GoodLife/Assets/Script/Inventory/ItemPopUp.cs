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
    private Text _input;

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
