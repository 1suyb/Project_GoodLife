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

    [Header("현재 숙련도 레벨")]
    #region
    [SerializeField] private byte _pfc_level_max_hp;        // 10
    [SerializeField] private byte _pfc_level_max_mp;        // 20
    [SerializeField] private byte _pfc_level_attack;        // 30
    [SerializeField] private byte _pfc_level_move_speed;    // 40
    [SerializeField] private byte _pfc_level_eat;           // 51
    [SerializeField] private byte _pfc_level_watering;      // 52
    [SerializeField] private byte _pfc_level_water;         // 60
    [SerializeField] private byte _pfc_level_fire;          // 61
    [SerializeField] private byte _pfc_level_ice;           // 62
    [SerializeField] private byte _pfc_level_earth;         // 63
    #endregion

    [Header("현재 목표 숙련도 경험치")]
    #region
    [SerializeField] private float _pfc_goal_method_max_hp;            // 10
    [SerializeField] private float _pfc_goal_method_max_mp;            // 20
    [SerializeField] private float _pfc_goal_method_attack;            // 30
    [SerializeField] private float _pfc_goal_method_move_speed;        // 40
    [SerializeField] private float _pfc_goal_method_eat;               // 51
    [SerializeField] private float _pfc_goal_method_watering;          // 52
    [SerializeField] private float _pfc_goal_method_fire;              // 61
    [SerializeField] private float _pfc_goal_method_ice;               // 62
    [SerializeField] private float _pfc_goal_method_earth;             // 63
    #endregion

    [Header("현재 숙련도 경험치")]
    #region
    [SerializeField] private float _pfc_method_max_hp;            // 10
    [SerializeField] private float _pfc_method_max_mp;            // 20
    [SerializeField] private float _pfc_method_attack;            // 30
    [SerializeField] private float _pfc_method_move_speed;        // 40
    [SerializeField] private float _pfc_method_eat;               // 51
    [SerializeField] private float _pfc_method_watering;          // 52
    [SerializeField] private float _pfc_method_fire;              // 61
    [SerializeField] private float _pfc_method_ice;               // 62
    [SerializeField] private float _pfc_method_earth;             // 63
    #endregion
    [Header("현재 자원 값")]
    [SerializeField] private float _hp;
    [SerializeField] private float _mp;

    // status 증감
    #region
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
    #endregion

    // 숙련도 경험치 증가
    #region
    public float pfc_method_max_hp
    {
        get
        {
            return _pfc_method_max_hp;
        }
        set
        {
            _pfc_method_max_hp += value;
            if (_pfc_method_max_hp >= _pfc_goal_method_max_hp)
            {
                float tmp = _pfc_method_max_hp - _pfc_goal_method_max_hp;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_max_hp = tmp;
            }
        }
    }
    public float pfc_method_max_mp
    {
        get
        {
            return _pfc_method_max_mp;
        }
        set
        {
            _pfc_method_max_mp += value;
            if (_pfc_method_max_mp >= _pfc_goal_method_max_mp)
            {
                float tmp = _pfc_method_max_mp - _pfc_goal_method_max_mp;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_max_mp = tmp;
            }
        }
    }
    public float pfc_method_attack
    {
        get
        {
            return _pfc_method_attack;
        }
        set
        {
            _pfc_method_attack += value;
            if (_pfc_method_attack >= _pfc_goal_method_attack)
            {
                float tmp = _pfc_method_attack - _pfc_goal_method_attack;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_attack = tmp;
            }
        }
    }
    public float pfc_method_move_speed
    {
        get
        {
            return _pfc_method_move_speed;
        }
        set
        {
            _pfc_method_move_speed += value;
            if (_pfc_method_move_speed >= _pfc_goal_method_move_speed)
            {
                float tmp = _pfc_method_move_speed - _pfc_goal_method_move_speed;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_move_speed = tmp;
            }
        }
    }
    public float pfc_method_eat
    {
        get
        {
            return _pfc_method_eat;
        }
        set
        {
            _pfc_method_eat += value;
            if (_pfc_method_eat >= _pfc_goal_method_eat)
            {
                float tmp = _pfc_method_eat - _pfc_goal_method_eat;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_eat = tmp;
            }
        }
    }
    public float pfc_method_watering
    {
        get
        {
            return _pfc_method_watering;
        }
        set
        {
            _pfc_method_watering += value;
            if (_pfc_method_watering >= _pfc_goal_method_watering)
            {
                float tmp = _pfc_method_watering - _pfc_goal_method_watering;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_watering = tmp;
            }
        }
    }
    public float pfc_method_fire
    {
        get
        {
            return _pfc_method_fire;
        }
        set
        {
            _pfc_method_fire += value;
            if (_pfc_method_fire >= _pfc_goal_method_fire)
            {
                float tmp = _pfc_method_fire - _pfc_goal_method_fire;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_fire = tmp;
            }
        }
    }
    public float pfc_method_ice
    {
        get
        {
            return _pfc_method_ice;
        }
        set
        {
            _pfc_method_ice += value;
            if (_pfc_method_ice >= _pfc_goal_method_ice)
            {
                float tmp = _pfc_method_ice - _pfc_goal_method_ice;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_ice = tmp;
            }
        }
    }
    public float pfc_method_earth
    {
        get
        {
            return _pfc_method_earth;
        }
        set
        {
            _pfc_method_earth += value;
            if (_pfc_method_earth >= _pfc_goal_method_earth)
            {
                float tmp = _pfc_method_earth - _pfc_goal_method_earth;
                // 데이터베이스에서 다음 숙련도 찾아와서
                // 세팅해주고
                _pfc_method_earth = tmp;
            }
        }
    }
    #endregion

    // 자원 증감
    #region
    public float hp
    {
        get => _hp;
        set
        {

        }
    }
    public float mp
    {
        get => _mp;
        set
        {
            _mp += value;
        }
    }
    #endregion

    // 버프 적용
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

    // 버프해제
    public void EndBuffStat()
    {

    }

    // 숙련도 레벨 업
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