using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour
{
    public Image indic;
    public GunScript gun;

    // Update is called once per frame
    void Update()
    {
        indic.fillAmount = Mathf.Lerp(0, 1, gun.timer / gun.cooldown);

        if (!gun.restraining)
        {
            if (indic.fillAmount > 0.5)
            {
                indic.color = Color.Lerp(Color.yellow, Color.green, (indic.fillAmount - .5f) * 2);
            }
            else
            {
                indic.color = Color.Lerp(Color.red, Color.yellow, indic.fillAmount * 2);
            }
        }
        else indic.color = Color.cyan;
    }
}
