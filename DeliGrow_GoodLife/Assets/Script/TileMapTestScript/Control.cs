using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Control : MonoBehaviour
{
    [SerializeField]
    [Tooltip("케릭터가 움직일 속도")]
    private float speed = 5f;

    [SerializeField]
    [Tooltip("배경 타일맵")]
    private Tilemap backGroundTileMap;
    
    [SerializeField]
    [Tooltip("")]
    private Tilemap plantTileMap;

    [SerializeField]
    [Tooltip("경작된땅 타일들")]
    private TileBase[] cultivatedTiles = new TileBase[9];

    [SerializeField]
    [Tooltip("젖은 땅의 이름")]
    private TileBase[] wetTiles = new TileBase[9];
    
    [SerializeField]
    [Tooltip("맨땅의 이름")]
    private string nomalTileName = "Nomal";

    [SerializeField]
    [Tooltip("경작된땅의 이름")]
    private string cultivatedTileName = "Cultivated";

    [SerializeField]
    [Tooltip("젖은 땅의 이름")]
    private string wetTileName = "Wet";

    [SerializeField]
    [Tooltip("식물기본프리팹")]
    private GameObject plantPrefeb;

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
    /*
    void changeTile(Vector3Int posi){
        string posiname = tile.GetTile(posi).name;
        string[] tilename = posiname.Split('_');
        if(tilename[0]!=digtilename){
            tile.SetTile(getTilePosition(this.transform.position),changetiles[4]);
        }
        else{
            string[] NearbyTiles = new string[3];
            bool[] f_sameTypeTile = new bool[3];
            Vector3Int[] NearbyTilePosi = new Vector3Int[3];
            if(playerLookDirect[0]){
                NearbyTilePosi[0] = posi+new Vector3Int(-1,1,0);
                NearbyTilePosi[1] = posi+new Vector3Int(0,1,0);
                NearbyTilePosi[2] = posi+new Vector3Int(1,1,0);

                NearbyTiles[0] = tile.GetTile(NearbyTilePosi[0]).name;
                NearbyTiles[1] = tile.GetTile(NearbyTilePosi[1]).name;
                NearbyTiles[2] = tile.GetTile(NearbyTilePosi[2]).name;

                foreach(string name in NearbyTiles){
                    tilename = name.Split('_');
                    if(tilename[0] == digtilename && tilename[2]==digtilename){
                        tile.SetTile(NearbyTilePosi[0],changetiles[0]);
                        tile.SetTile(NearbyTilePosi[2],changetiles[2]);
                        
                    }
                    else if()
                }
                
            }
            if(playerLookDirect[1]){
                NearbyTiles[0] = tile.GetTile(posi+new Vector3Int(-1,-1,0)).name;
                NearbyTiles[1] = tile.GetTile(posi+new Vector3Int(0,-1,0)).name;
                NearbyTiles[2] = tile.GetTile(posi+new Vector3Int(1,-1,0)).name;
            }
            if(playerLookDirect[2]){
                NearbyTiles[0] = tile.GetTile(posi+new Vector3Int(-1,1,0)).name;
                NearbyTiles[1] = tile.GetTile(posi+new Vector3Int(-1,0,0)).name;
                NearbyTiles[2] = tile.GetTile(posi+new Vector3Int(-1,-1,0)).name;
            }
            if(playerLookDirect[3]){
                NearbyTiles[0] = tile.GetTile(posi+new Vector3Int(1,1,0)).name;
                NearbyTiles[1] = tile.GetTile(posi+new Vector3Int(1,0,0)).name;
                NearbyTiles[2] = tile.GetTile(posi+new Vector3Int(1,-1,0)).name;
            }
        }
    }
    */
    
    void Interaction(){
        Vector3Int position = GetTilePosition(this.transform.position);
        string posiname = backGroundTileMap.GetTile(position).name;
        string[] tilename = posiname.Split('_');
        if (tilename[0] == nomalTileName){
            ChangeTile(position,cultivatedTileName);
        }
        else if(tilename[0] == cultivatedTileName){
            if(plant!=null){
                Plant plantndata = plant.GetComponent<Plant>();
                plantndata.F_Watering = true;
                ChangeTile(position,wetTileName);
            }
            else{
                Planting(position);
            }
        }
        else if(tilename[0] == wetTileName){
            Debug.Log("이미 젖은 땅");
        }
        else {
            Debug.Log("아무것도 못하는 땅");
        }
        Debug.Log(tilename[0]);
    }
    void ChangeTile(Vector3Int posi, string changetilename){
        int index = RuleTile(posi);
        if(changetilename == cultivatedTileName){
            backGroundTileMap.SetTile(posi,cultivatedTiles[index]);
        }
        else if(changetilename == wetTileName){
            backGroundTileMap.SetTile(posi,wetTiles[index]);
        }
    }
    int RuleTile(Vector3Int posi){
        /*
            인접타일의 번호를 보고 규칙에 따라 깔릴 타일의 번호를 정해주는 함수
        */
        return 0;
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

        if (UnityEngine.Input.GetKey(KeyCode.Space)&&!f_space){
            f_space = true;
            Interaction();            
            f_space = false;
        }
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
        }
    }
    void OneClick(){
        f_space = false;
    }
}
