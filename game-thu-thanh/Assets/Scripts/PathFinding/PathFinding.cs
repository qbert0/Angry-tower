using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridTile))]
public class PathFinding : MonoBehaviour
{
    [SerializeField] public GridTile gridTile;
    public PathNode [,] pathNodes;
    void Start()
    {
        Init();
    }

    private void Init() {
        if (gridTile == null) {gridTile = GetComponent<GridTile>();}
        pathNodes = new PathNode[gridTile.Width(), gridTile.Height()];

        for(int x = 0; x < gridTile.Width(); x++) {
            for(int y =0; y < gridTile.Height(); y++) {
                pathNodes[x,y] = new PathNode(x,y);
            }
        }
    }

    public List<PathNode> FindPath(int startX, int startY, int endX, int endY) {
        PathNode startNode = pathNodes[startX, startY];
        PathNode endNode = pathNodes[endX, endY];

        List<PathNode> openList = new List<PathNode>();
        List<PathNode> closeList = new List<PathNode>();

        openList.Add(startNode);

        while(openList.Count > 0) {
            PathNode currentNode = openList[0];
            for (int i = 0; i < openList.Count; i++ ) {
                if (currentNode.fValue > openList[i].fValue) {
                    currentNode = openList[i];
                }
                if (currentNode.fValue == openList[i].fValue && currentNode.hValue > openList[i].hValue) {
                    currentNode = openList[i];
                }
            }
            openList.Remove(currentNode);
            closeList.Add(currentNode);
            
            if (currentNode == endNode) {
                // finish
                return RetracePath(startNode, endNode);
            }
            // Debug.Log("currentNode :" + currentNode.xPos + " " + currentNode.yPos);
            // add neighbourNode
            List<PathNode> neighbourNodes = new List<PathNode>();
            for (int x = 0; x < 1; x++) {
                for (int y = -1; y < 2; y++) {
                    if(x== 0 && y== 0) {continue;}
                    if(gridTile.CheckPos(currentNode.xPos + x, currentNode.yPos + y) == false) {
                        continue; // check pos
                    }
                    if(gridTile.CheckElement(currentNode.xPos + x, currentNode.yPos + y) == false) {
                        continue; // check elemnet
                    }
                    if(gridTile.CheckHighLight(currentNode.xPos + x, currentNode.yPos + y) == false) {
                        continue; // check hight light
                    }
                    neighbourNodes.Add(pathNodes[currentNode.xPos+x, currentNode.yPos + y]);
                }
            }

            for (int x = -1; x < 2; x++) {
                for (int y = 0; y < 1; y++) {
                    if(x== 0 && y== 0) {continue;}
                    if(gridTile.CheckPos(currentNode.xPos + x, currentNode.yPos + y) == false) {
                        continue; // check pos
                    }
                    if(gridTile.CheckElement(currentNode.xPos + x, currentNode.yPos + y) == false) {
                        continue; // check elemnet
                    }
                    if(gridTile.CheckHighLight(currentNode.xPos + x, currentNode.yPos + y) == false) {
                        continue; // check hight light
                    }
                    neighbourNodes.Add(pathNodes[currentNode.xPos+x, currentNode.yPos + y]);
                }
            }

            for (int i =0 ; i< neighbourNodes.Count; i++) {
                // Debug.Log("neighbourNode  :" + neighbourNodes[i].xPos + " " + neighbourNodes[i].yPos);
                if(closeList.Contains(neighbourNodes[i])) {continue;}
                
                int movementCost = currentNode.gValue + calculateDistance(currentNode, neighbourNodes[i]);
                if(openList.Contains(neighbourNodes[i]) == false ||
                movementCost< neighbourNodes[i].gValue) {

                    neighbourNodes[i].gValue = movementCost;
                    neighbourNodes[i].hValue = calculateDistance(neighbourNodes[i], endNode);
                    neighbourNodes[i].parentNode = currentNode;

                    if(openList.Contains(neighbourNodes[i]) == false) {
                        openList.Add(neighbourNodes[i]);
                    }
                }
            }
        }
        return null;
    }

    private List<PathNode> RetracePath(PathNode startNode, PathNode endNode) {
        List<PathNode> path = new List<PathNode>();

        PathNode currentNode = endNode;

        while (currentNode != startNode) 
        {
            path.Add(currentNode);
            currentNode = currentNode.parentNode;
        }
        path.Add(currentNode);
        path.Reverse();

        return path;
    }

    private int calculateDistance(PathNode current, PathNode target) {
        int distX = Mathf.Abs(current.xPos - target.xPos);
        int distY = Mathf.Abs(current.yPos - target.yPos);
        return 10 * (distX + distY);
    } 
}
