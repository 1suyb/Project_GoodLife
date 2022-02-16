using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.transform.position+new Vector3(0,0,-10);
    }
}
