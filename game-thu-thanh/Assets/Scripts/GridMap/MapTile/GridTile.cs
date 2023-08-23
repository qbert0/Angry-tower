using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    [HideInInspector]
    private int height;
    [HideInInspector]
    private int width;
    Node [,] grid;
    

    public void Init(MapData mapData) {
        this.width = mapData.width;
        this.height = mapData.height;
        grid = new Node[this.width, this.height];
        int i =0;
        for (int x = 0; x < width; x++) {
            for (int y =0; y < height; y++) {
                grid[x,y] = new Node();
                grid[x,y].tile = mapData.map[i];
                grid[x,y].element = null;
                grid[x,y].highLight = false;
                i++;
            }
        }
    }

    public void Clear() {
        for(int x =0; x < width; x++) {
            for(int y =0; y < height; y++ ) {
                grid = null;
            }
        }
    }

    // element
    public void SetElemnt(MapElement mapElement, int x, int y) {
        grid[x,y].element = mapElement.GetComponent<Element>();
    }

    public void ClearElement( int x, int y) {
        grid[x,y].element = null;
    }

    public Element GetElement(int x, int y) {
        return grid[x,y].element;
    }

    // high Light
    public void SetHighLight(int x, int y, bool to) {
        grid[x,y].highLight = to;
    }

    public void ClearAllHightLight() {
        for (int x = 0; x < width; x++) {
            for (int y =0; y < height; y++) {
                grid[x,y].highLight = false;
            }
        }
    }

    public bool GetHighLight(int x, int y) {
        return grid[x,y].highLight;
    }

    // check something
    public bool CheckPos(int x, int y) {
        if (x < 0 || x >= width ||y < 0 || y >= height) {
            return false;
        } else if (grid[x,y].tile == false) {
            return false;
        } else {
            return true;
        }
    }

    public bool CheckElement(int x, int y) {
        if(grid[x,y].element == null) {
            return true;
        } else {
            return false;
        }
    }

    public bool CheckHighLight(int x, int y) {
        if (grid[x,y].highLight == false) {
            return true;
        } else {
            return false;
        }
    }

    // tile
    public void Set(int x, int y, bool to) {
        grid[x,y].tile = to;
    }
    

    public bool Pos(int x, int y) {
        return grid[x,y].tile;
    }

    public int Width() {
        return width;
    }

    public int Height() {
        return height;
    }

}
