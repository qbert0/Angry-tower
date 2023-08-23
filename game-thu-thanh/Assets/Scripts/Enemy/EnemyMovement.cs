using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private List<Vector2> road;

    public EnemyCtrl enemyCtrl;
    private int index;
    void Start()
    {
        enemyCtrl = GetComponent<EnemyCtrl>();
        index = 0;
    }

    void Update()
    {
        Move();
    }

    private void Move() {
        var step = speed * Time.deltaTime;
        
        if (this.road.Count == 0) {
            return;
        }
        if (road != null) {
            if(index >= road.Count) {
                return;
            }
            Vector2 target = road[index];
            this.transform.position = Vector2.MoveTowards(this.transform.position, target, step);
            if(Vector2.Distance(transform.position, target) < 0.0001f) {
                index++;
            }
        } else {
            Debug.Log("road null");
        }

        
    }

    public void TakeRoad(List<Vector2> road) {
        this.road = road;
    }

    
}
