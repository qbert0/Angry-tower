using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(1f,20f)]
    [SerializeField] private float damage =2f;

    [Range(0.00001f,5f)]
    [SerializeField] private float fireRate;
    private float fireTimer = 0f;

    [SerializeField] private GunCtrl gunCtrl;

    private void Awake() {
        // gunCtrl = GetComponent<GunCtrl>();
    }

    

    void Update()
    {
        if(gunCtrl.GetCanShoot() == false) {
            return;
        }
        if(gunCtrl.gunDitect.GetTarget() == null) {
            fireTimer = 0f;
            return;
        }
        if(gunCtrl.gunForward.GetArealdy() == false) {
            fireTimer = 0f;
            return;
        }
        Shoot();
        
    }

    private void Shoot() {
        if (fireTimer <= 0f) {
            Bullet bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            bullet.SetTarget(gunCtrl.gunDitect.GetTarget().transform);
            bullet.SetDamage(damage);
            fireTimer = fireRate;
        } else {
            fireTimer -= Time.deltaTime;
        }
    }
}
