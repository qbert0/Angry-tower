using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyRoad : MonoBehaviour
{
    [SerializeField] private PathFinding pathFinding;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Transform goal;
    [SerializeField] private Transform start;

    
    private Vector3Int posStart;
    private Vector3Int posGoal;
    private List<PathNode> path;
    private List<PathNode> virPath;
    private List<Vector2> road;
    private int i;
    void Start()
    {
        path = new List<PathNode>();
        virPath = new List<PathNode>();
        road = new List<Vector2>();
        SetGoalStart();
    }

    void Update()
    {
        if(CheckPathIsNullExist()) {
            ConvertRoad();
        }
    }

    public void SetGoalStart() {
        posStart = gridManager.GetWorldToCell(start.position);
        posGoal = gridManager.GetWorldToCell(goal.position);
        Debug.Log(posStart.x + " " + posStart.y);
        Debug.Log(posGoal.x + " " + posGoal.y);
    }

    public bool CheckPathIsNullExist() {
        path = pathFinding.FindPath(posStart.x, posStart.y, posGoal.x, posGoal.y);
        if (path == null) {
            Debug.Log("path null");
            return false;
        }
        return true;
    }


    public void ConvertRoad() {
        Clear();
        // Debug.Log("new road");
        for(int i = 0; i< path.Count; i++) {
            road.Add(SetCellToPos(path[i]));
        }
       
    }

    public bool Alike(List<PathNode> listOne, List<PathNode> listTwo) {
        if(listOne.Count != listTwo.Count) {
            return false;
        }
        for (int i =0; i< listOne.Count; i++) {
            if(listOne[i] == listTwo[i]) {
                return false;
            }
        }
        return true;
    }
    public Vector2 SetCellToPos(PathNode pathNode) {
        Vector2 worldPos = gridManager.GetCellToWorld(pathNode.xPos, pathNode.yPos);
        return worldPos;
    }

    public void Clear() {
        road = new List<Vector2>();
    }

    public List<Vector2> GetRoad() {
        if (road == null) {
            Debug.Log("null road");
            return null;
        }
        return road;
    }





}
