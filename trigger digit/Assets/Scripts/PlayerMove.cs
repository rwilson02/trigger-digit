using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController cont;
    public float speed = 1f;
    public float gravity = -9.81f;
    public float height = 3f;

    public Transform groundCheck;
    public float groundDist;
    public LayerMask mask;

    Vector3 vel;
    bool grounded;

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDist, mask);

        if(grounded && vel.y < 0)
        {
            vel.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cont.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            vel.y = Mathf.Sqrt(-2f * height * gravity);
        }

        vel.y += gravity * Time.deltaTime;
        cont.Move(vel * Time.deltaTime);
    }
}
