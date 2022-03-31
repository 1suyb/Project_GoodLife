using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : ScriptableObject
{
    private float _max_hp;
    private float _max_mp;
    private float _power;
    private float _move_speed;
    private float _attack_speed;

    private int _attack_range;
    private int _projectiles_size;
    private int _attack_value;
    private int _attack_count;

    private float _up_max_hp;
    private float _up_max_mp;
    private float _up_power;
    private float _up_move_speed;
    private float _up_attack_speed;
    public float max_Hp{
        get
        {
            return _max_hp;
        }
        set
        {
            _up_max_hp = value;
            _max_hp += value;
        }
    }
    public float max_Mp
    {
        get
        {
            return _max_mp;
        }
        set
        {
            _up_max_mp = value;
            _max_mp += value;
        }
    }
    public float power
    {
        get
        {
            return _power;
        }
        set
        {
            _up_power = value;
            _power += value;
        }
    }
    public float move_Speed
    {
        get
        {
            return _move_speed;
        }
        set
        {
            _up_move_speed = value;
            _move_speed += value;
        }
    }
    public float attack_Speed
    {
        get
        {
            return _attack_speed;
        }
        set
        {
            _up_attack_speed = value;
            _attack_speed += value; 
        }
    }

    public void BuffStat(byte stattype, float value)
    {
        switch (stattype)
        {
            case 11:
                max_Hp = value;
                break;
            case 12:
                max_Mp = value;
                break;
            case 13:
                power = value;
                break;
            case 14:
                move_Speed = value;
                break;
            case 21:
                attack_Speed = value;
                break;
            default:
                break;
        }
    }
    public void EndBuffStat()
    {

    }

    public void UpProficiency(byte stattype, float value)
    {
        switch (stattype)
        {
            case 11:
                _max_hp += value;
                break;
            case 12:
                _max_mp += value;
                break;
            case 13:
                _power += value;
                break;
            case 14:
                _move_speed += value;
                break;
            case 21:
                _attack_speed += value;
                break;
            default:
                break;
        }
    }

}
