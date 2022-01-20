using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [Tooltip("ItemIcon을 넣을 게임 오브젝트")]
    public GameObject itemIconObject;

    private Image m_itemIconImage;
    public Image itemIconImage
    {
        get => m_itemIconImage;
        set => m_itemIconImage = value;
    }

    [Tooltip("ItemCount텍스트를 넣을 게임 오브젝트")]
    public GameObject itemCountObject;

    private TextMeshProUGUI m_itemCountText;
    public TextMeshProUGUI itemCountText
    {
        get => m_itemCountText;
        set => m_itemCountText = value;
    }

    [Range(0,1)]
    [Tooltip("비활성화시 RGB값")]
    public float deactivateRGB;
    [Range(0, 1)]
    [Tooltip("비활성화시 Alpha값")]
    public float deactivateAlpha;

    // 비활성화시 적용할 컬러
    private Vector4 m_deactivateColor;
    public Vector4 deactivateColor
    {
        get => m_deactivateColor;
        set => m_deactivateColor = value;
    }

    // 활성화시 적용할 컬러
    private Vector4 m_activateColor;
    public Vector4 activateColor
    {
        get => m_activateColor;
        set => m_activateColor = value;
    }


    






    // Start is called before the first frame update
    void Start()
    {
        m_itemCountText = itemCountObject.GetComponent<TextMeshProUGUI>();
        m_itemIconImage = itemIconImage.GetComponent<Image>();

        m_deactivateColor = new Vector4(deactivateRGB, deactivateRGB, deactivateRGB, deactivateAlpha);
        m_activateColor = new Vector4(1, 1, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
