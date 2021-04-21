using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcontAnim : PlayerMove
{
    public Animator Animator;
    //public float normSpeed;

    //private void Start()
    //{
    //    Animator.SetFloat("speedMult",Mathf.InverseLerp(0, normSpeed, speed));
    //}

    protected void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDist, mask);

        if (grounded && vel.y < 0)
        {
            vel.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Animator.SetFloat("x", x);
        Animator.SetFloat("z", z);

        cont.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            vel.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
        }

        vel.y += gravity * Time.deltaTime;
        cont.Move(vel * Time.deltaTime);
    }
}
