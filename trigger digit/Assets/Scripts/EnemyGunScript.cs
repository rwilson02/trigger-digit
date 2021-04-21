using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunScript : GunScript
{
    public GameObject bullet;
    public bool shoot = false;

    private void Start()
    {
        timer = cooldown;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            if (shoot) { ShootAtWill(); }
            timer = cooldown;
        }
    }

    void ShootAtWill()
    {
        Instantiate(flash, muzzle, false);
        Instantiate(bullet, muzzle.position, muzzle.rotation);
    }
}
