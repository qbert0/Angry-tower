using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HealtSystem;

public class EnemyCtrl : MonoBehaviour
{

    private int damage;
    public EnemyHealth enemyHealth;
    public EnemyMovement enemyMovement;
    private int id;

    private void Awake() {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyMovement = GetComponent<EnemyMovement>();
        id = -1;
        damage = 2;
    }

    public int GetDamage() {
        return damage;
    }


    public int GetId() {
        return id;
    }

    public void SetId(int id) {
        this.id = id;
    }

    public void Death() {
        Destroy(gameObject);
    }
}
