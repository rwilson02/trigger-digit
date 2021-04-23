using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnocentScript : HumanoidScript
{
    public override void Die(PlayerScript from = null)
    {
        if(from != null)
        {
            from.FeelBadAbtIt();
            print("you done messed up, from: " + gameObject.name);
        }
        gameObject.SetActive(false);
    }
}
