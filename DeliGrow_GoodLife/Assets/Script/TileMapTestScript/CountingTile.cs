using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "VinTools/Custom Tiles/Counting Tile")]
public class CountingTile : Tile
{
    [Header("Counting tile")]
    public Sprite[] sprites;
    //public TileBase[] tilesToCheck;

    private TileBase[] nearbyTile = new TileBase[9];
    private 

    //determines which Tiles in the vicinity are updated when this Tile is added to the Tilemap
    public override void RefreshTile(Vector3Int location, ITilemap tilemap){
        for (int xd = -1; xd <= 1; xd++){
            for (int yd = -1; yd <= 1; yd++){
                tilemap.RefreshTile(location + new Vector3Int(xd, yd, 0));
            }
        }
    }

    //determines what the Tile looks like on the Tilemap
    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData){
        //get these values from the base class
        base.GetTileData(location, tilemap, ref tileData);
        tileData.sprite = sprites[getIndex()];
        tileData.transform.SetTRS(location,getRotation(),new Vector3(1,1,1));
    }

    int GetNeighbor(Vector3Int location, ITilemap tilemap){
        for(int yd = 1; yd >= -1; yd++){
            for (int xd = -1; xd <= 1; xd++){
                
            }
        }
        /*
            상하 좌우 타일 검사
            대각선 검사
        */
    }
    int getIndex(int sum){
        /*
            검사한거 이용해서 인덱스 뱉기
        */

    }

    Quaternion getRotation(int sum){
        /*
            회전시키기
        */

    }
    
#if UNITY_EDITOR
    [MenuItem("Assets/Create/VinTools/Custom Tiles/Counting Tile")]
    public static void CreateCountingTile(){
        string path = EditorUtility.SaveFilePanelInProject("Save Counting Tile", "New Counting Tile", "Asset", "Save Counting Tile", "Assets");
        if (path == "") return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<CountingTile>(), path);
    }
#endif
}