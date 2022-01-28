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

    private readonly string DUMPTITLE = "������";
    private readonly string DEVIDETITLE = "������";
    private readonly string DESCRIPTION = "������ �Է��ϼ���";

    private ItemData _handlingItem;

    public delegate void FunctionPointer(ItemData a);

    private FunctionPointer action;

    public void DumpItem(ItemData item, FunctionPointer act)
    {
        _handlingItem = item.Clone();
        this.gameObject.SetActive(true);
        _title.text = DUMPTITLE;
        _description.text = DESCRIPTION;
        action = act;
    }
    public void DevideItem(ItemData item, FunctionPointer act)
    {
        _handlingItem = item.Clone();
        this.gameObject.SetActive(true);
        _title.text = DEVIDETITLE;
        _description.text = DESCRIPTION;
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

    }

}
