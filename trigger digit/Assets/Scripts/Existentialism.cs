using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Existentialism : MonoBehaviour
{
    public float timeOut;
    void Update()
    {
        timeOut -= Time.deltaTime;

        if(timeOut < 0)
        {
            Destroy(gameObject);
        }
    }
}
