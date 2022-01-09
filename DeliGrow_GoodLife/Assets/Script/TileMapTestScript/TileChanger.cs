using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChanger : MonoBehaviour
{
    private string nomalTileName;
    private string cultivatedTileName;
    private string wetTileName;
    private Tilemap tilemap;
    private TileBase[] normalTiles;
    private TileBase[] cultivatedTiles;
    private TileBase[] wetTiles;

    private int[] weight = new int[4]{2,3,5,7};
    private int cross;
    private int diagonal;
    private int[] topDown = new int[4];
    private int[] cross = new int[4];
    public void SetTile(Vector3Int posi, string tilename){

    }
    int getIndex(Vector3Int posi,string changetilename){
        int td = 0, cr = 0;
        for(int yd = 1; yd >= -1; yd--){
            for(int xd = -1; xd <= 1; xd++){
                if(yd == 0 && xd == 0){

                }
                else if (yd ==0 || xd == 0){
                    if()
                    //topDown[td] = weight[td];
                    //td++;
                }
                else{
                    //cross[cr] = weight[cr];
                    //cr++;
                }
            }
        }

    }
    void changeTile(Vector3Int posi, int index){

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
