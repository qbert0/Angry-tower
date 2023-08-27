using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Bullet  : MonoBehaviour
{
    [Range(1,20)]
    [SerializeField] private float speed = 5f;
    [Range(1,10)]
    [SerializeField] private float lifeTime = 3f;
    [Range(1f,20f)]
    [SerializeField] private float damage =2f;


    
    private Transform target;
    private Transform targetVir;
    private Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null) RotateTowardsTarget();
    }
    private void FixedUpdate() {
        myRb.velocity = transform.up * speed;
    }

    public void SetTarget(Transform targetEnenmy) {
        target = targetEnenmy;
    }

    public void SetDamage(float damage) {
        this.damage = damage;
    }

    public float GetDamage() {
        return damage;
    }
    private void RotateTowardsTarget() {
        targetVir = target;
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<EnemyCtrl>(out EnemyCtrl enemy)) {
            if(enemy != null) {
                // Debug.Log(enemy.name);
                // Debug.Log(enemy.enemyCtrl);
                // Debug.Log(enemy.enemyCtrl.enemyHealth);
                enemy.enemyHealth.TakeHit(damage);
            }
           
            Destroy(gameObject);
        }
    }
}
