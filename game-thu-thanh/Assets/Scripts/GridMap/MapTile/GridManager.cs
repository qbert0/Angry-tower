using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GridTile gridTile;
    [SerializeField] private TileSet tileSet;
    [SerializeField] private SaveLoadMap saveLoadMap;
    private void Awake() {
        Clear();
        saveLoadMap.Load(gridTile);
        UpdateTileMap();
    }

    // load on runtime
    public void Load(MapData mapData) {
        // gridTile.Clear();
        gridTile.Init(mapData);
        UpdateTileMap();
    }
    
    // update tile on the grid map
    private void UpdateTileMap() {
        for(int x = 0; x<gridTile.Width(); x++) {
            for(int y = 0; y < gridTile.Height(); y ++) {
                if(gridTile.Pos(x,y)) {
                    tilemap.SetTile(new Vector3Int(x,y,0), tileSet.tiles[0]);
                } else {
                    tilemap.SetTile(new Vector3Int(x,y,0), tileSet.tiles[1]);
                }
            }
        }
    }

    // check highLight anh pos put
    public bool CheckHighLight(int x, int y) {
        if(gridTile.CheckPos(x,y)) {
            if(gridTile.CheckElement(x,y)) {
                return true;
            }
        } 
        
        return false;
    }

    // read tile map for spawn
    public bool[,] ReadTileMap() {
        if(tilemap == null) {
           tilemap = GetComponent<Tilemap>(); 
        }
        tilemap.GetComponent<Tilemap>().CompressBounds();
        int size_x = tilemap.size.x;
        int size_y = tilemap.size.y;
        Debug.Log("size map " + size_x + " " + size_y);
        bool [,] tilemapData = new bool[size_x,size_y];

        for(int x =0; x < size_x; x ++) {
            for(int y =0; y < size_y; y++) {
                TileBase tileBase = tilemap.GetTile(new Vector3Int(x,y,0));
                if(tileSet.tiles[0] == tileBase) {
                    tilemapData[x,y] = true;
                } else {
                    tilemapData[x,y] = false;
                }
            }
        }

        return tilemapData;
    }

    public void Clear() {
        tilemap.ClearAllTiles();
    }

    // element on the gird map
    public void SetElemnt(MapElement mapElement, int x, int y) {
        gridTile.SetElemnt(mapElement, x, y);
    }

    public void ClearElement( int x,int y) {
        gridTile.ClearElement( x, y);
    }

    public Element GetElement(int x, int y) {
        return gridTile.GetElement(x,y);
    }


    // pos sawnp world anh cell
    // cell anh pos is different. pos is position reality. cell is position in unity
    public Vector3 GetPosToWorld(int x, int y) {
        Vector3 gridPos = tilemap.CellToWorld(new Vector3Int(x,y,0));
        gridPos -= new Vector3(0.5f,0.5f,0);
        return gridPos;
    }

    public Vector2 GetCellToWorld(int x, int y) {
        Vector2 gridPos = tilemap.CellToWorld(new Vector3Int(x,y,0));
        gridPos += new Vector2(0.5f, 0.5f);
        return gridPos;

    }

    public Vector3 GetWorldToCenterCell(Vector3 worldPos) {
        Vector3Int gridPos = tilemap.WorldToCell(worldPos);
        Vector3 gridPosCenter = tilemap.CellToWorld(gridPos);
        gridPosCenter += new Vector3(0.5f, 0.5f,0f);
        return gridPosCenter;
    }

    public Vector3Int GetWorldToCell(Vector3 worldPos) {
        Vector3Int gridPos = tilemap.WorldToCell(worldPos);

        return gridPos;
    }

}
