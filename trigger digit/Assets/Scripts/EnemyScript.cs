using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : HumanoidScript
{
    public NavMeshAgent pathfinder;
    public Transform muzzle;
    public float visionRange;
    public GameObject player;
    public EnemyGunScript gunScript;
    public bool LOS = false, initial = true;
    public LayerMask mask;

    GameObject target;
    Ray ray;

    private void Update()
    {
        if (initial && !LOS)
        {
            ray = new Ray(muzzle.position, muzzle.forward);
            Debug.DrawRay(ray.origin, ray.direction * visionRange, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit, visionRange) && hit.collider.gameObject == player)
            {
                print("SPOTTED");
                initial = false;
                LOS = true;
                gunScript.shoot = true;
                target = player;
            }
        }
        
        if(!initial)
        {
            ray = new Ray(muzzle.position,
                    (target.transform.position - transform.position)*2);
            Physics.Raycast(ray, out RaycastHit hit, mask);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            print(hit.collider);

            if (LOS)
            {
                transform.LookAt(target.transform);
                
                if (hit.collider != null && hit.collider.gameObject != player)
                {
                    print("OUTTA SIGHT");
                    pathfinder.SetDestination(target.transform.position);
                    pathfinder.isStopped = false;
                    gunScript.shoot = false;
                    LOS = false;
                }
            }
            else if(hit.collider != null && hit.collider.gameObject == player)
                {
                    print("I SEE YOU");
                    pathfinder.isStopped = true;
                    gunScript.shoot = true;
                    LOS = true;
                }
            }
        }
    }
