using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightGrid : MonoBehaviour
{
    private bool [,] grid;
    private int width;
    private int height;
    

    public void Load(GridTile gridTile) {
        width = gridTile.Width();
        height = gridTile.Height();
        grid = new bool[width,height];

        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                grid[x, y] = gridTile.Pos(x, y);
            }
        }
    }

    public bool CheckIsGrid(Vector3Int pos) {
        if(pos.x < 0 || pos.x >= width || pos.y < 0 || pos.y >= height) {
            return false;
        } else if (grid[pos.x, pos.y] == false) {
            return false;
        } else {
            return true;
        }

    }
}
