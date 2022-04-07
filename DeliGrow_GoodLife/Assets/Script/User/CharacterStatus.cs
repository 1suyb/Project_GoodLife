using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterStatus", menuName = "Scriptable Object/CharacterStatus")]
public class CharacterStatus : ScriptableObject
{
    [Header("����ǰ� �ִ� ���� ��")]
    #region
    [Tooltip("���� �Ӽ�")]
    [SerializeField] private byte _element;             // 0~4;
    [Tooltip("�ִ� ü��")]
    [SerializeField] private float _max_hp;             // 11
    [Tooltip("�ִ� ���")]
    [SerializeField] private float _max_mp;             // 12
    [Tooltip("���ݷ�")]
    [SerializeField] private float _power;              // 13
    [Tooltip("�̵��ӵ�")]
    [SerializeField] private float _move_speed;         // 14
    [Tooltip("���ݼӵ�")]
    [SerializeField] private float _attack_speed;       // 21
    [Tooltip("���ݹ���")]
    [SerializeField] private int _attack_range;         // 22
    [Tooltip("��ü ũ��")]
    [SerializeField] private int _projectiles_size;     // 23
    [Tooltip("����Ÿ�Կ� ���� ��")]
    [SerializeField] private int _attack_value;         // 24
    [Tooltip("�ش� �Ӽ� �ִ� ���� Ƚ��")]
    [SerializeField] private int _attack_count;
    #endregion

    [Header("������ ���� ���� ��")]
    #region
    [SerializeField] private float _up_max_hp;
    [SerializeField] private float _up_max_mp;
    [SerializeField] private float _up_power;
    [SerializeField] private float _up_move_speed;
    [SerializeField] private float _up_attack_speed;
    #endregion

    [Header("���� ���õ� ����")]
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

    [Header("���� ��ǥ ���õ� ����ġ")]
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

    [Header("���� ���õ� ����ġ")]
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
                // �����ͺ��̽����� ���� ���õ� ã�ƿͼ�
                // �������ְ�
                _pfc_method_max_hp = tmp;
            }
        }
    }
    public float pfc_method_max_mp
    {
        get
        {
            return _pfc_method_max_hp;
        }
        set
        {

        }
    }
    public float pfc_method_attack
    {
        get
        {
            return _pfc_method_max_hp;
        }
        set
        {

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
        }
    }
    public float pfc_method_eat
    {
        get
        {
            return _pfc_method_max_hp;
        }
        set
        {

        }
    }
    public float pfc_method_watering
    {
        get
        {
            return _pfc_method_max_hp;
        }
        set
        {

        }
    }
    public float pfc_method_fire
    {
        get
        {
            return _pfc_method_max_hp;
        }
        set
        {

        }
    }
    public float pfc_method_ice
    {
        get
        {
            return _pfc_method_max_hp;
        }
        set
        {

        }
    }
    public float pfc_method_earth
    {
        get
        {
            return _pfc_method_max_hp;
        }
        set
        {

        }
    }

    // ���� ����
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

    // ��������
    public void EndBuffStat()
    {

    }

    // ���õ� ���� ��
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