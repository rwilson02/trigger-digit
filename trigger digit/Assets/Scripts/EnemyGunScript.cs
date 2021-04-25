using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunScript : GunScript
{
    public GameObject bullet;
    public bool shoot = false;
    public float pause = 0.5f, pauseTmr;
    EnemyScript scr;

    private void Start()
    {
        timer = cooldown;
        pauseTmr = pause;
        scr = GetComponentInParent<EnemyScript>();
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            scr.look = false;
            pauseTmr -= Time.deltaTime;

            if (pauseTmr < 0 && shoot) { 
                ShootAtWill();
                timer = cooldown;
                pauseTmr = pause;
            }
        }
    }

    void ShootAtWill()
    {
        
        Instantiate(flash, muzzle, false);
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out RaycastHit hit, range))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            if (hit.collider.TryGetComponent(out HumanoidScript hitScript))
            {
                hitScript.Hit();
            }
        }
        Instantiate(flash, muzzle, false);
    }
}
