using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontCleaner : MonoBehaviour
{
    public Font[] fonts;

    void Start()
    {
        //��Ʈ�� Pixel Perfect �ϰ� ���̵��� ����
        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
    }
}
