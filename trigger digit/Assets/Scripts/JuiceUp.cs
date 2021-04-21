using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceUp : MonoBehaviour
{
    public void PowerUp(GunScript gun)
    {
        gun.restraint += 25;
        Destroy(gameObject);
    }
}
