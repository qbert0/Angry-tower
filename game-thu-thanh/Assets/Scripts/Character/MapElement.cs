using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Element))]
public class MapElement : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    private int x_pos;
    private int y_pos;
    // Start is called before the first frame update
    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        transform.position = gridManager.GetWorldToCenterCell(transform.position);
        PlaceObjectOnGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // set object on grid
    public void PlaceObjectOnGrid() {
        GetPosElement();
        Debug.Log("x and y :" + x_pos + " " + y_pos);
        gridManager.SetElemnt(this, x_pos,y_pos);
    }

    public void RemoveObjectOnGrid() {
        GetPosElement();
        gridManager.ClearElement(x_pos, y_pos);
    }

    public void GetPosElement() {
        Transform t = this.transform;
        Vector3 pos = t.position;
        x_pos = (int)pos.x;
        y_pos = (int)pos.y;
    }
}
