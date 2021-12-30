using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private bool f_space = false;
    Vector3 getTilePosition(Vector3 posi){
        int x,y,z;
        z = (int)posi.z;
        if((posi.x*posi.x) %1 > 0.25 )
            x = posi.x > 0 ? (int)posi.x+1:(int)posi.x-1; 
        else
            x = (int)posi.x; 

        if((posi.y*posi.y) %1 > 0.25 )
            y = posi.y > 0 ? (int)posi.y+1:(int)posi.y-1; 
        else
            y = (int)posi.y; 
        
        Vector3 tileposi = new Vector3(x,y,z);
        return tileposi;
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.W))
            this.transform.position += new Vector3(0, 1, 0) * speed* Time.deltaTime;
        if (UnityEngine.Input.GetKey(KeyCode.S))
            this.transform.position += new Vector3(0, -1, 0) * speed*Time.deltaTime;
        if (UnityEngine.Input.GetKey(KeyCode.A))
            this.transform.position += new Vector3(-1, 0, 0) * speed*Time.deltaTime;
        if (UnityEngine.Input.GetKey(KeyCode.D))
            this.transform.position += new Vector3(1, 0, 0) * speed*Time.deltaTime;
        if(UnityEngine.Input.GetKey(KeyCode.Space)&&!f_space){
            f_space = true;
            Debug.Log(this.transform.position+"실제위치");
            Debug.Log(getTilePosition(this.transform.position)+"보정위치");
            f_space = false;
        }
        

    }
}
