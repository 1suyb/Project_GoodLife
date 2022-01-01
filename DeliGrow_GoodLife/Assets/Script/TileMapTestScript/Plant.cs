using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private GameObject crop;
    private bool f_watering;
    public bool F_Watering{
        set{f_watering = value;}
    }
    private int days;
    public int Days{
        set{days = value;}
    }
    private int maxDay;
    public int MaxDay{
        set{maxDay = value;}
    }
    void StartDay(){
        if(f_watering){
            days++;
        }
        f_watering = false;
    }
    public void Harvested(Vector3 posi){
        if(maxDay==days){
            /*
            프리팹에 드랍할 작물에 대한 정보 넣기
            */
            Instantiate(crop,posi,Quaternion.identity);
            /*
            if로 분기 나눠서 여러번 수확 할 수 있는 작물인지 플레그 확인하고
            트루이면 삭제하지말고 스프라이트 변경후 days 변수 감소
            페일이면 삭제
            */
            Destroy(this.gameObject);
        } 
    
    }

    void OnCollisionEnter2D(Collision2D col){

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
