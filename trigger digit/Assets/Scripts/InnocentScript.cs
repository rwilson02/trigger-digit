using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InnocentScript : HumanoidScript
{
    Animator anim;
    NavMeshAgent path;
    int i;

    public enum MoveType { Idle, Wander };
    public MoveType movement;
    public Transform[] waypt;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        path = gameObject.GetComponent<NavMeshAgent>();
        i = 0;
    }

    private void Update()
    {
        anim.SetFloat("Velocity", path.velocity.magnitude);
        if (movement == MoveType.Wander) { CheckMove(); }
    }

    public override void Die(PlayerScript from = null)
    {
        if(from != null)
        {
            from.FeelBadAbtIt();
            print("you done messed up, from: " + gameObject.name);
        }
        gameObject.SetActive(false);
    }

    public void CheckMove()
    {
        if(Vector3.Distance(transform.position, path.destination) < 0.2)
        {
            if (i == waypt.Length - 1) { i = 0; } else { i++; }
            path.destination = new Vector3(waypt[i].position.x, transform.position.y, waypt[i].position.z);
            //print(i.ToString() + " " + waypt[i]);
        }
    }
}
