using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    [SerializeField]
    private CharacterStatus status;
    private bool activetimer = false;
    private void Update()
    {
        
    }
    public void GoUp()
    {
        transform.Translate(0, status.move_Speed * Time.fixedDeltaTime, 0);
        if (!activetimer)
        {
            activetimer = true;
            status.pfc_method_move_speed = Time.fixedDeltaTime;
            activetimer = false;
        }
    }

    public void GoDown()
    {
        transform.Translate(0, -status.move_Speed * Time.fixedDeltaTime, 0);
        if (!activetimer)
        {
            activetimer = true;
            status.pfc_method_move_speed = Time.fixedDeltaTime;
            activetimer = false;
        }
    }

    public void GoLeft()
    {
        transform.Translate(-status.move_Speed * Time.fixedDeltaTime, 0, 0);
        if (!activetimer)
        {
            activetimer = true;
            status.pfc_method_move_speed = Time.fixedDeltaTime;
            activetimer = false;
        }
    }

    public void GoRight()
    {
        transform.Translate(status.move_Speed * Time.fixedDeltaTime, 0, 0);
        if (!activetimer)
        {
            activetimer = true;
            status.pfc_method_move_speed = Time.fixedDeltaTime;
            activetimer = false;
        }
    }

    public void Eat()
    {

    }

    public void Split()
    {

    }

    public void Watering()
    {

    }

    public void SeedPlant()
    {

    }

    public void Attack()
    {

    }

    public void ChangeElement()
    {

    }

}
