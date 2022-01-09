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
    private int cross = 1;
    private int diagonal = 1;
    
    public void SetTile(Vector3Int posi, string tilename){

    }
    /*
    int getIndex(Vector3Int posi,string changetilename){
        int i =0 , j = 0;
        
        for(int yd = 1; yd >= -1; yd--){
            for(int xd = -1 ; xd >= 1; xd++){
                if(xd == 0 && yd == 0){
                    continue;
                }
                else if(xd == 0 || yd == 0){
                    if(tilemap.GetTile(posi+new Vector3Int(xd,yd,0)).name == changetilename){
                        cross = cross*weight[i];
                    }
                    i++;
                }
                else{
                    if(tilemap.GetTile(posi+new Vector3Int(xd,yd,0)).name == changetilename){
                        diagonal = diagonal*weight[j];
                    }
                    j++;
                }
            }
        }

        if(cross == 360){                    // 4방향
            if(diagonal == 360){
                return 12;
            }
            else if(60 < diagonal && diagonal < 120){
                return 11;
            }
            else if(12 < diagonal && diagonal < 30){
                return 10;
            }
            else{
                return 9;
            }
        }

        else if(60 < cross && cross < 120){      // 3방향
            if(cross%6 != 0){
                if(diagonal % 30 == 0){
                    // retrun |
                }
                else if (diagonal%6 == 0 || diagonal%5 == 0){
                    // return |ㄴ
                }
            }
            else if(cross%5 != 0){
                if(diagonal % 20 == 0){
                    // retrun |
                }
                else if (diagonal%5 == 0 || diagonal%4 == 0){
                    // return |ㄴ
                }
            }
            else if(cross%4 != 0){
                if(diagonal % 12 == 0){
                    // retrun |
                }
                else if (diagonal%4 == 0 || diagonal%3 == 0){
                    // return |ㄴ
                }
            }
            else if(cross%3 != 0){
                if(diagonal % 18 == 0){
                    // retrun |
                }
                else if (diagonal%6 == 0 || diagonal%3 == 0){
                    // return |ㄴ
                }
            }
            else{
                // 한칸짜리
            }
        }
        else if(12 < cross && cross < 38){        // 2방향
            switch(cross){s
                case 12 : 
                    if(diagonal%6 == 0&&diagonal%3 == 0){
                        // 3
                    }
                    else if(diagonal %3 == 0){
                        // 3
                    }
                case 20 :
                    if(diagonal%4 == 0){
                        // 3
                    }
                case 30 :
                    if(diagonal%5 == 0){
                        // 3
                    }
                case 18 : 
                    if(diagonal%6 == 0){
                        // 3
                    }
                    // return 꺽인길
                case 15 : 
                case 24 :
                    // 리턴 그냥 직진
                break;
            }
        }
        else if(3<cross){                               // 1방향
            switch (cross){
                case 3 :
                case 4 :
                case 5 :
                case 6 :

                break;
            }
        }
        else{

        }
    }

    Quaternion GetQuaternion(){
        if(cross == 360){                    // 4방향
            if(diagonal == 360){
                return 12;
            }
            else if(60 < diagonal && diagonal < 120){
                return 11;
            }
            else if(12 < diagonal && diagonal < 30){
                return 10;
            }
            else{
                return 9;
            }
        }
        else if(60 < cross && cross < 120){      // 3방향
            if(cross%6 != 0){
                if(diagonal % 30 == 0){
                    // retrun |
                }
                else if (diagonal%6 == 0 || diagonal%5 == 0){
                    // return |ㄴ
                }
            }
            else if(cross%5 != 0){
                if(diagonal % 20 == 0){
                    // retrun |
                }
                else if (diagonal%5 == 0 || diagonal%4 == 0){
                    // return |ㄴ
                }
            }
            else if(cross%4 != 0){
                if(diagonal % 12 == 0){
                    // retrun |
                }
                else if (diagonal%4 == 0 || diagonal%3 == 0){
                    // return |ㄴ
                }
            }
            else if(cross%3 != 0){
                if(diagonal % 18 == 0){
                    // retrun |
                }
                else if (diagonal%6 == 0 || diagonal%3 == 0){
                    // return |ㄴ
                }
            }
            else{
                // 한칸짜리
            }
        }
        else if(12 < cross && cross < 38){        // 2방향
            switch(cross){
                case 12 : 
                    if(diagonal%6 == 0&&diagonal%3 == 0){
                        // 3 O
                    }
                    else if(diagonal %3 == 0){
                        // 3 O
                    }
                case 20 :
                    if(diagonal%4 == 0){

                    }
                case 30 :
                    if(diagonal%5 == 0){

                    }
                case 18 : 
                    if(diagonal%6 == 0){

                    }
                case 15 : 
                case 24 :
                    // 리턴 그냥 직진
                break;
            }
        }
        else if(3<cross){                               // 1방향
            switch (cross){
                case 3 :
                case 4 :
                case 5 :
                case 6 :

                break;
            }
        }
        else{

        }
    }*/
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
