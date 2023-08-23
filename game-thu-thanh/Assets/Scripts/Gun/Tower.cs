using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate =0.5f;
    private float fireTimer;
    private Rigidbody2D myRb;
    private float pos_x;
    private float pos_y;
    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Gun();
        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f ) {
            
            fireTimer = fireRate;   
        } else {
            fireTimer -= Time.deltaTime;
        }
    }
    
    private void FixedUpdate() {
        myRb.velocity = new Vector2(pos_x, pos_y).normalized * speed;
    }


}
