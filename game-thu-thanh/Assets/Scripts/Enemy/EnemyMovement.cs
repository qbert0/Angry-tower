using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private List<Vector2> road;
    private List<Vector2> atack;

    private Vector2 posNow;

    // public EnemyCtrl enemyCtrl;
    private int index;
    private int indexAtack;
    void Start()
    {
        // enemyCtrl = GetComponent<EnemyCtrl>();
        posNow = transform.position;
        CreatAtack();
        index = 0;
    }

    void Update()
    {
        Move();
    }

    private void CreatAtack() {
        atack = new List<Vector2>();
        atack.Add(new Vector2(-6, 0));
        atack.Add(new Vector2( 0, 3));
        indexAtack = 0;
    }

    private void Move() {
        var step = speed * Time.deltaTime;
        
        if (this.road.Count == 0) {
            return;
        }
        if (road != null) {
            if(index >= road.Count) {
                
                Atack();
                return;
            }
            Vector2 target = road[index];
            this.transform.position = Vector2.MoveTowards(this.transform.position, target, step);
            if(Vector2.Distance(transform.position, target) < 0.0001f) {
                index++;
                SetPosNow();
            }
        } else {
            Debug.Log("road null");
        }
    }

    public void TakeRoad(List<Vector2> road) {
        this.road = road;
    }

    private void SetPosNow() {
        posNow = transform.position;
    }

    public void Atack() {
        var step = speed * Time.deltaTime;
        if(indexAtack >= atack.Count) {
            return;
        }
        Vector2 target = posNow + atack[indexAtack];

        this.transform.position = Vector2.MoveTowards(this.transform.position, target, step);
        if(Vector2.Distance(transform.position, target) < 0.0001f) {
            indexAtack += 1;
            SetPosNow();
        } 
    }

    
}
