using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Control : MonoBehaviour
{
    [SerializeField]
    [Tooltip("케릭터가 움직일 속도")]
    private float speed = 5f;

    [Tooltip("배경 타일맵")]
    public Tilemap BackGroundTileMap;

    [Tooltip("경작된 땅 타일베이스")]
    public TileBase CultivatedTile;

    [Tooltip("젖은 땅 TileBase")]
    public TileBase WetTile;

    [Tooltip("일반 땅 이름")]
    public string NormalTilename;

    [Tooltip("경작된 땅 이름")]
    public string CultivatedTileName;

    [Tooltip("젖은 땅 이름")]
    public string WetTileName;
    [Tooltip("심을 식물 프리팹")]
    public GameObject plantPrefeb;
    /*
    [SerializeField]
    [Tooltip("")]
    private Tilemap plantTileMap;
    */
    
    private bool[] playerLookDirect = new bool[4] ;
    private bool f_space = false;
    private GameObject plant;
    Vector3Int GetTilePosition(Vector3 posi){
        int x,y,z;
        z = (int)posi.z;

        float fx = posi.x%1;
        float fy = posi.y%1;

        if((fx*fx) > 0.25 )
            x = posi.x > 0 ? (int)posi.x+1:(int)posi.x-1; 
        else
            x = (int)posi.x; 

        if((fy*fy) %1 > 0.25 )
            y = posi.y > 0 ? (int)posi.y+1:(int)posi.y-1; 
        else
            y = (int)posi.y; 
        
        Vector3Int tileposi = new Vector3Int(x,y,z);
        return tileposi;
    }
    
    void Interaction(){
        Vector3Int position = GetTilePosition(this.transform.position);
        string[] tilename = new string[2];
        tilename = BackGroundTileMap.GetTile(position).name.Split('_');
        if(tilename[0] == NormalTilename){
            cultivating(position);
        }
        else if(tilename[0] == CultivatedTileName){
            watering(position);
        }
    }
    void cultivating(Vector3Int position){
        
        BackGroundTileMap.SetTile(position,CultivatedTile);
    }
    void watering(Vector3Int position){
        
        BackGroundTileMap.SetTile(position,WetTile);
        if(plant != null){
            Plant plantinfo = plant.GetComponent<Plant>();
            plantinfo.F_Watering = true;
        }
        
        
    }

    void Planting(Vector3Int posi){
        if(plant != null){
            return;
        }
        /*
        프리팹 스크립트에 각종 정보를 넣어주는 과정
        
        */
        Instantiate(plantPrefeb,posi,Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Plant"){
            plant = col.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject == plant){
            plant = null;
        }
    }
    void Start(){
        for(int i = 0 ;i<playerLookDirect.Length;i++){
            playerLookDirect[i] = false;
        }
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.W)){
            this.transform.position += new Vector3(0, 1, 0) * speed* Time.deltaTime;
            for(int i = 0 ;i<playerLookDirect.Length;i++){
                 playerLookDirect[i] = false;
            }
            playerLookDirect[0] = true;
        }

        if (UnityEngine.Input.GetKey(KeyCode.S)){
            this.transform.position += new Vector3(0, -1, 0) * speed*Time.deltaTime;
            for(int i = 0 ;i<playerLookDirect.Length;i++){
                 playerLookDirect[i] = false;
            }
            playerLookDirect[1] = true;
        }

        if (UnityEngine.Input.GetKey(KeyCode.A)){
            this.transform.position += new Vector3(-1, 0, 0) * speed*Time.deltaTime;
            for(int i = 0 ;i<playerLookDirect.Length;i++){
                 playerLookDirect[i] = false;
            }
            playerLookDirect[2] = true;
        }

        if (UnityEngine.Input.GetKey(KeyCode.D)){
            this.transform.position += new Vector3(1, 0, 0) * speed*Time.deltaTime;
            for(int i = 0 ;i<playerLookDirect.Length;i++){
                 playerLookDirect[i] = false;
            }
            playerLookDirect[3] = true;
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space)&&!f_space){
            f_space = true;
            Interaction();
            //Vector3Int posi = GetTilePosition(this.transform.position);
            //Debug.Log(backGroundTileMap.GetTransformMatrix(posi));
        }
        if(UnityEngine.Input.GetKeyUp(KeyCode.Space)){
            f_space = false;
        }
        /*
        if(UnityEngine.Input.GetKey(KeyCode.F)&&!f_space){
            f_space = true;
            Planting(GetTilePosition(this.transform.position));
            Invoke("OneClick",0.3f);
        }
        if(UnityEngine.Input.GetKey(KeyCode.Z)){
            if(plant != null){
                Plant p = plant.GetComponent<Plant>();
                p.MaxDay = 3;
                p.Days = 3;
                p.Harvested(this.transform.position);
            }
        }*/
    }
    void OneClick(){
        f_space = false;
    }
}
