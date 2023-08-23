using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode 
{
    public int xPos;
    public int yPos;
    public int gValue;
    public int hValue;
    public PathNode parentNode;

    public int fValue {
        get{
            return gValue + hValue;
        }
    }

    public PathNode(int xPos, int yPos) {
        this.xPos = xPos;
        this.yPos = yPos;
    }
    
}
