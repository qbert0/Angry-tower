using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighLight : MonoBehaviour
{
    [SerializeField] private TileSet tileSet;
    [SerializeField] private Tilemap highLight;
    [SerializeField] private GridTile Grid;
    [SerializeField] private EnenmyRoad road;
    private enum Color {
        inSide, unValid, outSide
    }

    private Color color;

    private void Start() {
        color = Color.outSide;
    }


    public void HighLightOnePos(Vector3Int pos) {
        Grid.ClearAllHightLight();
        highLight.ClearAllTiles();


        if(Grid.CheckPos(pos.x, pos.y)) {
            Grid.SetHighLight(pos.x,pos.y, true);
            
            if(road.CheckPathIsNullExist() == false) {
                color = Color.unValid;
            } else if(Grid.CheckElement(pos.x, pos.y) == false) {
                color = Color.unValid;
            } else {
                color = Color.inSide;
            }
        } else {
            color = Color.outSide;
        }
        HighLighTile(pos);
        
    }
    public void HighLighTile(Vector3Int pos) {
        highLight.SetTile(pos, tileSet.tiles[(int)color]);
    }
    public bool CheckPut() {
        if(color == Color.inSide) {
            return true;
        }
        return false;
    }

    public void PutTower() {
        color = Color.outSide;
        Grid.ClearAllHightLight();

    }
}
