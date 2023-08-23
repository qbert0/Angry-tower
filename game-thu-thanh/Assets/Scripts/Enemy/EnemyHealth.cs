using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 0;
    [Range(1f,30f)]
    [SerializeField] private float maxHitPoint = 30;
    public HealthBar healthBar;
    void Start()
    {
        if (healthBar != null) {
            healthBar.setMaxHealth( maxHitPoint);
        }
        hitPoints = maxHitPoint;
    }


    public void TakeHit(float damage) {
        hitPoints -= damage;
        healthBar.setHealth(hitPoints);
        if (hitPoints <= 0) {
            Destroy(gameObject);
        }
    }
}
