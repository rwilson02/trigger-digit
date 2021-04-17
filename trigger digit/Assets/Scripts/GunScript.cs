﻿using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Camera cam;
    public Transform muzzle;
    
    public float cooldown = 1f, timer;
    public bool restraining;
    public int restraint = 10;

    float range = 100f;

    private void Start()
    {
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        restraining = EvalRestraint();

        

        if (timer < 0)
        {
            Shoot(restraining);
            timer = cooldown;
        }
        else timer -= Time.deltaTime;
    }

    void Shoot(bool res)
    {
        //print(res);
        if (!res)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward * range, out RaycastHit hit))
            {
                print(hit.transform.gameObject);
            }
        }
        else
        {
            restraint--;
            print(restraint);
        }
    }

    bool EvalRestraint()
    {
        if (Input.GetButton("Fire1") && restraint > 0) { return true; } else return false;
    }
}