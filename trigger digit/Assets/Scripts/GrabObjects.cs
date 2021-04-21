using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    public string grabTag = "Grabbable";
    public string powerTag = "Powerup";
    public KeyCode grabKey;
    public float grabRange = 2;

    Camera cam;
    GunScript gun;
    bool grasping = false;
    Transform held;

    private void Start()
    {
        cam = Camera.main;
        gun = GetComponentInChildren<GunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            Grasp();
            GetPower();
        }

        if (held != null && Vector3.Distance(cam.transform.position, held.position) > grabRange*2)
        {
            ToggleGrab(held);
        }
        
    }

    void Grasp()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, grabRange)
            && hit.transform.CompareTag(grabTag))
        {
            ToggleGrab(hit.transform);
        }
    }

    void ToggleGrab(Transform grabbed)
    {
        if (!grasping)
        {
            held = grabbed;
            grabbed.GetComponent<Rigidbody>().useGravity = false;
            grabbed.parent = cam.transform;
        }
        else
        {
            grabbed.GetComponent<Rigidbody>().useGravity = true;
            grabbed.parent = null;
            held = null;
        }

        grasping = !grasping;
    }

    void GetPower()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, grabRange)
            && hit.transform.CompareTag(powerTag))
        {
            hit.transform.GetComponent<JuiceUp>().PowerUp(gun);
        }
    }
}
