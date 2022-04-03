using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterProficiency", menuName = "Scriptable Object/CharacterProficiency")]

public class CharacterProficiency : ScriptableObject
{
    private byte _pfc_level_max_mp;
    private byte _pfc_level_attack;
    private byte _pfc_level_move_speed;
    private byte _pfc_level_eat;
    private byte _pfc_level_watering;
    private byte _pfc_level_water;
    private byte _pfc_level_fire;
    private byte _pfc_level_ice;
    private byte _pfc_level_earth;
    [SerializeField]
    private Dictionary<byte, PFC> _proficiency = new Dictionary<byte, PFC>()
    {
        {10, new PFC()},
        {20, new PFC()},
        {30, new PFC()},
        {40, new PFC()},
        {51, new PFC()},
        {60, new PFC()},
        {61, new PFC()},
        {62, new PFC()},
        {63, new PFC()}

    };
}
[Serializable]
public struct PFC
{
    public int value;
    public int maxvalue;
}