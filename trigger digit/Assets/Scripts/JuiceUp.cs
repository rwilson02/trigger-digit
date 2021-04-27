using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceUp : MonoBehaviour
{
    public int restore = 10;
    public void PowerUp(GunScript gun)
    {
        gun.restraint += restore;
        Destroy(gameObject);
    }
}
