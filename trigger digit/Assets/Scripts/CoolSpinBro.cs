﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolSpinBro : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
}
