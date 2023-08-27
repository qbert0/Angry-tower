using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunForward : MonoBehaviour
{
    
    [Range(0.00005f, 1)]
    [SerializeField] private float FowardTime;

    private GunCtrl gunCtrl;

    private bool arealdy;

    
    private GameObject target;
    private void Awake() {
        gunCtrl = GetComponent<GunCtrl>();
    }

    private void Start() {
        arealdy = false;
    }

    void Update()
    {
        if (gunCtrl.gunDitect.GetTarget() != null) {
            Fowward();
        } else {
            SetArealdy(false);
        }
        
    }


    private void Fowward () {
        Vector3 target = gunCtrl.gunDitect.GetTarget().transform.position;
        
        float angle = Mathf.Atan2(target.y - transform.position.y,
                        target.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion q = Quaternion.Euler(0,0, angle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, FowardTime);

        float goc3 = Quaternion.Angle(transform.localRotation, q);
        
        if(goc3 < 1f) {
            SetArealdy(true);
        } 
    }

    private void SetArealdy(bool to) {
        arealdy = to;
    }

    public bool GetArealdy() {
        return arealdy;
    }

}
