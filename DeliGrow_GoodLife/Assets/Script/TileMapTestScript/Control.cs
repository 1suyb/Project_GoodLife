using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.W))
            this.transform.position += new Vector3(0, 1, 0) * speed;
        if (UnityEngine.Input.GetKey(KeyCode.S))
            this.transform.position += new Vector3(0, -1, 0) * speed;
        if (UnityEngine.Input.GetKey(KeyCode.A))
            this.transform.position += new Vector3(-1, 0, 0) * speed;
        if (UnityEngine.Input.GetKey(KeyCode.D))
            this.transform.position += new Vector3(1, 0, 0) * speed;

    }
}
