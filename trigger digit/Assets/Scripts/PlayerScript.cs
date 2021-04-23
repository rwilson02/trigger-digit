using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : HumanoidScript
{
    public void FeelBadAbtIt()
    {
        reputation--;

        if(reputation == 0)
        {
            Murderer();
        }
    }

    public void Murderer()
    {
        print("seeya bastud");
        gameObject.SetActive(false);
    }
}
