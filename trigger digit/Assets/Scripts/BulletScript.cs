using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 12f;
    public float existence = 5f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (existence > 0)
        {
            existence -= Time.deltaTime;
        }
        else Destroy(gameObject);
    }
}
