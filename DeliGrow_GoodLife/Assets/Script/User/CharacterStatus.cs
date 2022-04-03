using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterStatus", menuName = "Scriptable Object/CharacterStatus")]
public class CharacterStatus : ScriptableObject
{
    [Header("적용되고 있는 스텟 값")]
    #region
    [Tooltip("현재 속성")]
    [SerializeField] private byte _element;             // 0~4;
    [Tooltip("최대 체력")]
    [SerializeField] private float _max_hp;             // 11
    [Tooltip("최대 기력")]
    [SerializeField] private float _max_mp;             // 12
    [Tooltip("공격력")]
    [SerializeField] private float _power;              // 13
    [Tooltip("이동속도")]
    [SerializeField] private float _move_speed;         // 14
    [Tooltip("공격속도")]
    [SerializeField] private float _attack_speed;       // 21
    [Tooltip("공격범위")]
    [SerializeField] private int _attack_range;         // 22
    [Tooltip("구체 크기")]
    [SerializeField] private int _projectiles_size;     // 23
    [Tooltip("공격타입에 따른 값")]
    [SerializeField] private int _attack_value;         // 24
    [Tooltip("해당 속성 최대 공격 횟수")]
    [SerializeField] private int _attack_count;
    #endregion
    [Header("버프로 인한 증감 값")]
    #region
    [SerializeField] private float _up_max_hp;
    [SerializeField] private float _up_max_mp;
    [SerializeField] private float _up_power;
    [SerializeField] private float _up_move_speed;
    [SerializeField] private float _up_attack_speed;
    #endregion

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
    public void UpProficienty(byte stattype, float value)
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

}
