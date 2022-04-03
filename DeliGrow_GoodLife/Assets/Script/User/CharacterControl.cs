using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    private Transform transform;
    [SerializeField]
    private CharacterStatus status;
    public void GoUp()
    {
        transform.Translate(0, status.move_Speed * Time.deltaTime, 0);
    }

    public void GoDown()
    {
        transform.Translate(0, -status.move_Speed * Time.deltaTime, 0);
    }

    public void GoLeft()
    {
        transform.Translate(-status.move_Speed * Time.deltaTime, 0, 0);
    }

    public void GoRight()
    {
        transform.Translate(status.move_Speed * Time.deltaTime, 0, 0);
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
