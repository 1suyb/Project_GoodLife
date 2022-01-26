using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontCleaner : MonoBehaviour
{
    public Font[] fonts;

    void Start()
    {
        //폰트가 Pixel Perfect 하게 보이도록 설정
        for (int i = 0; i < fonts.Length; i++)
        {
            fonts[i].material.mainTexture.filterMode = FilterMode.Point;
        }
    }
}
