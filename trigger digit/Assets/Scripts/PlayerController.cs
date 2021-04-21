using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public CharacterController controller;

    // Update is called once per frame
    protected void Update()
    {
        float movX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float movY = Physics.gravity.y * Time.deltaTime;
        float movZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 movement = new Vector3(movX, movY, movZ);

        controller.Move(movement);

       // movement.normalized;
       //transform.forward is where the front of the object is facing
    }
}
