using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MonoBehaviour
{
    public GunForward gunForward;
    public GunDitect gunDitect;
    public GunTarget gunTarget;

    [SerializeField] private bool canShoot;

    private void Awake() {
        gunDitect = GetComponent<GunDitect>();
        gunForward = GetComponent<GunForward>();
        gunTarget = GetComponent<GunTarget>();
    }

    

    private void Start() {
        canShoot = true;
    }

    public bool GetCanShoot() {
        return canShoot;
    }

}
