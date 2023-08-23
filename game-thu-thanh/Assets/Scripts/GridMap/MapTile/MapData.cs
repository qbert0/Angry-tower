using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("map data"))]
public class MapData : ScriptableObject
{
    public int width;
    public int height;

    public List<bool> map;

    public void Load(GridTile gridTile) {
        gridTile.Init(this);
    }

    public void Load(MapData mapData){
        
    }
    

    private bool Pos(int x, int y) {
        int index = x* height + y;
        if(index >= map.Count) {
            Debug.Log("loi lef");
            return false;
        }
        return map[index];
    }

    public void Save(GridTile gridTile) {
        height = gridTile.Height();
        width = gridTile.Width();

        map = new List<bool>();
        for(int x =0; x < width; x++) {
            for(int y =0; y < height; y++) {
                map.Add(gridTile.Pos(x,y));
            }
        }
    }
    internal void Save(bool[,] map) {
        width = map.GetLength(0);
        height = map.GetLength(1);
        
        this.map = new List<bool>();

        for(int x =0; x < width; x++) {
            for(int y =0; y < height; y++) {
                this.map.Add(map[x,y]);
            }
        }
        // UnityEditor.EditorUtility.SetDirty(this);
    }
    
}
